using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Abstractions.Managers.Identity;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Enums.Authentication;
using Finanzauto.Identity.Api.Models.Credential.Dtos;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Managers.Identity;

public sealed class CredentialManager(IServiceProvider provider) : ICredentialManager
{
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();
  private readonly ISignatureKeyManager _signatureKeyManager = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IHashManager _hash = provider.GetRequiredService<IHashManager>();

  public async Task<Result<Unit>> Registry(Guid UserId, IEnumerable<CreateCredentialDto> credentials, CancellationToken cancellationToken)
  {
    IEnumerable<int> credentialValues = credentials
      .Select(c => c.LoginTypeId)
      .Distinct();

    IEnumerable<LoginType> logintypes = await _context
      .Repository<LoginType>()
      .AsNoTracking()
      .Where(row => credentialValues.Contains(row.Id))
      .ToListAsync(cancellationToken);

    foreach (CreateCredentialDto credential in credentials)
      if (logintypes.FirstOrDefault(row => row.Id == credential.LoginTypeId) is LoginType loginType)
      {
        if(loginType.AuthenticationType == AuthenticationTypes.DomainCredential)
        {
          DomainCredential domainCredential = new()
          {
            UserName = credential.UserName,
            LoginTypeId = credential.LoginTypeId,
            UserId = UserId,
          };
          _context.Add(domainCredential);
        }
        else if (loginType.AuthenticationType == AuthenticationTypes.SingleCredential)
        {
          Result<HashResponse> hash = await _hash.ComputeHash(credential.Password ?? _signatureKeyManager.NewString(), cancellationToken);
          if (hash.IsFailure)
            return Result.Failure<Unit>(hash.Erros);
          if(credential.ApplicationId == null)
            return Result.Failure<Unit>(StatusCodes.Status400BadRequest, new Error("ApplicationId.Required", "El id de la aplicación es requerido"));

          SingleCredential singleCredential = new()
          {
            AppId = credential.ApplicationId.Value,
            UserName = credential.UserName,
            UserId = UserId,
            PasswordHash = hash.Value.Hash,
            PasswordSalt = hash.Value.Salt
          };
          _context.Add(singleCredential);
        }
        else
          return Result.Failure<Unit>(StatusCodes.Status400BadRequest, new Error("LoginType.Invalid", $"El tipo de login {loginType.AuthenticationType} es invalido"));
      }
      else
        return Result.Failure(StatusCodes.Status404NotFound, new Error("LoginType.NotFound", $"Tipo de login con id {credential.LoginTypeId} no encontrado"));

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Unit;
  }
}
