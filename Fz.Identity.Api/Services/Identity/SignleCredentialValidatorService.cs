using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Models.Identity;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Text.Json;

namespace Fz.Identity.Api.Services.Identity;

public class SignleCredentialValidatorService(IServiceProvider provider) : ICredentialValidatorService
{
  private readonly IHashManager _hashManager = provider.GetRequiredService<IHashManager>();
  private readonly ISignatureKeyManager _keyManager = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IReadOnlyDbContext _context = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IDbContext _fullContext = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);

  public async Task<Result> CreateCredential(Guid userId, string username)
  {
    if (_context.Repository<Database.Entities.Credential>()
      .AsEnumerable()
      .Where(row => row.UserId == userId && row.CredentialTypeId == (int)CredentialTypes.PassWord && row.CredentialValue == username)
      .Any())
      return Result.Failure(ResultTypes.Conflict, [new Error("Credential.AlreadyExists", "Ya existe una credencial con ese nombre de usuario")]);

    string password = _keyManager.NewString();
    Result<HashResponse> hash = await _hashManager.ComputeHash(password, CancellationToken.None);

    Database.Entities.Credential credential = new()
    {
      UserId = userId,
      CredentialTypeId = (int)CredentialTypes.PassWord,
      CredentialValue = username,
      CredentialConfirmed = false,
      TwoFactorEnabled = false,
      PasswordHash = hash.Value.Hash,
      PasswordSalt = hash.Value.Salt
    };
    _fullContext.Add(credential);
    await _unitOfWork.SaveChangesAsync();

    return Result.Success(ResultTypes.Created);
  }

  public async Task<Result<User>> ValidateCredentials(JsonElement credential)
  {
    int credentialType = ((int)CredentialTypes.PassWord);
    if (!credential.TryGetProperty("userName", out JsonElement jsonUserName))
      return Result.Failure<User>(ResultTypes.BadRequest, [new Error("userName.Required", "nombre de usuario obligatorio")]);
    if (!credential.TryGetProperty("password", out JsonElement jsonPassword))
      return Result.Failure<User>(ResultTypes.BadRequest, [new Error("password.Required", "contraseña obligatoria")]);

    (string userName, string password) = (jsonUserName.GetString()!, jsonPassword.GetString()!);

    Database.Entities.Credential? credential1 = await _context.Repository<Database.Entities.Credential>()
      .Include(row => row.User)
      .ThenInclude(row => row.Applications)
      .FirstOrDefaultAsync(row => row.CredentialTypeId == credentialType && row.CredentialValue == userName);

    if(credential1 is null)
      return Result.Failure<User>(ResultTypes.NotFound, [new Error("Credential.NotFound", "Credencial no encontrada")]);

    return await _hashManager.ValidateHash(new HashRequest(
      password,
      credential1.PasswordHash!,
      credential1.PasswordSalt!
    ), CancellationToken.None, new Error("Credential.Invalid", "Credencial inválida"
    ))
      .Map(result => credential1.User);
  }
}
