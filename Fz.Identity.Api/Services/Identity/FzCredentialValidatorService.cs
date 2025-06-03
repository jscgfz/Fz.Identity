using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Services.Identity.Settings;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Fz.Identity.Api.Services.Identity;

public sealed class FzCredentialValidatorService(IServiceProvider provider) : ICredentialValidatorService
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IDbContext _fullContext = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IOptions<FzCredentialSettings> _settings = provider.GetRequiredService<IOptions<FzCredentialSettings>>();

  public async Task<Result> CreateCredential(Guid userId, string username)
  {
    if (_context.Repository<Credential>()
      .AsEnumerable()
      .Where(row => row.UserId == userId && row.CredentialTypeId == (int)CredentialTypes.FzDomain && row.CredentialValue == username)
      .Any())
      return Result.Failure(ResultTypes.Conflict, [new Error("Credential.AlreadyExists", "Ya existe una credencial con ese nombre de usuario")]);

    Credential credential = new()
    {
      UserId = userId,
      CredentialTypeId = (int)CredentialTypes.FzDomain,
      CredentialValue = username,
      CredentialConfirmed = false,
      TwoFactorEnabled = false
    };
    _fullContext.Add(credential);
    await _unitOfWork.SaveChangesAsync();

    return Result.Success(ResultTypes.Created);
  }

  public Task<Result<User>> ValidateCredentials(JsonElement credentials)
    => FindCredential(credentials)
      .Map(ValidateCredentials);

  private Task<Result<CredentialDto>> FindCredential(JsonElement credential)
  {
    int credentialType = ((int)CredentialTypes.FzDomain);
    if (!credential.TryGetProperty("userName", out JsonElement jsonUserName))
      return Task.FromResult(
        Result.Failure<CredentialDto>(ResultTypes.BadRequest, [new Error("userName.Required", "nombre de usuario obligatorio")])
      );
    if (!credential.TryGetProperty("password", out JsonElement jsonPassword))
      return Task.FromResult(
        Result.Failure<CredentialDto>(ResultTypes.BadRequest, [new Error("password.Required", "contraseña obligatoria")])
      );

    (string userName, string password) = (jsonUserName.GetString()!, jsonPassword.GetString()!);
    
    return Task.FromResult(
      Result.From(
        _context.Repository<Credential>()
          .AsEnumerable()
          .Select(row => new CredentialDto(
            row.CredentialValue,
            password,
            row.CredentialTypeId,
            row.UserId
          ))
          .FirstOrDefault(row => row.CredentialTypeId == credentialType && row.UserName == userName),
        ResultTypes.NotFound,
        [new Error("Credential.NotFound")]
      )
    );
  }

  private async Task<Result<User>> ValidateCredentials(CredentialDto credential)
  {
    using HttpClient client = new();
    HttpRequestMessage request = new(HttpMethod.Post, new Uri($"{_settings.Value.BaseUrl}RespuestaLg"))
    {
      Content = new StringContent(JsonSerializer.Serialize(new
      {
        User = credential.UserName,
        Passwd = credential.Password,
        IdAplicativo = _settings.Value.AppId,
        Firma = _settings.Value.Signature
      }), Encoding.UTF8, "application/json")
    };
    HttpResponseMessage response = await client.SendAsync(request);
    if (!response.IsSuccessStatusCode)
      return Result.Failure<User>(ResultTypes.BadRequest, [new Error("FinanzautoDomain.RequestError", $"Validación fallida - respuesta servicio {response.StatusCode}")]);

    JsonElement serviceResp = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
    if (!serviceResp.TryGetProperty("Mensaje", out JsonElement message))
      return Result.Failure<User>(ResultTypes.BadRequest, [new Error("FinanzautoDomain.RequestError", "Validación fallida - respuesta servicio sin mensaje")]);
    if (message.GetProperty("CodigoMensaje").GetInt32() != 0)
      return Result.Failure<User>(ResultTypes.BadRequest, [new Error("FinanzautoDomain.RequestError", $"Validación fallida - {message.GetProperty("DescMensaje").GetString()}")]);

    return Result.From(
      await _context.Repository<User>().Include(row => row.Applications).FirstOrDefaultAsync(row => row.Id == credential.UserId),
      ResultTypes.NotFound,
      [new Error("User.NotFound", "Usuario no encontrado en el sistema")]
    );
  }
}
