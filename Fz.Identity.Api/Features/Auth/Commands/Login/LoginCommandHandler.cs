using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Auth.Commands.Login;

public sealed class LoginCommandHandler(IServiceProvider provider) : ICommandHandler<LoginCommand, Result<IdentityResponseDto>>
{
  private readonly IServiceProvider _provider = provider;
  private readonly ITokenProviderService _tokenProvider = provider.GetRequiredKeyedService<ITokenProviderService>(ContextTypes.Identity);

  public async Task<Result<IdentityResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
  {
    if(request.CredentialType is null)
    {
      Application? app = await _provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity)
        .Repository<Application>()
        .Include(row => row.AllowedCredentials)
        .FirstOrDefaultAsync(row => row.Id == request.ApplicationId, cancellationToken);

      if (app is null)
        return Result.Failure<IdentityResponseDto>(ResultTypes.NotFound, [new Error("Domain.Error", $"Application with ID {request.ApplicationId} not found.")]);

      if(!app.MultDomainEnabled)
        return Result.Failure<IdentityResponseDto>(ResultTypes.NotFound, [new Error("Domain.Error", $"La aplicación no es multidominio {app.Name}")]);

      IEnumerable<Result<User>> results = await Task.WhenAll(
        app.AllowedCredentials
        .Select(allowedCredential => _provider.GetRequiredKeyedService<ICredentialValidatorService>((CredentialTypes)allowedCredential.CredentialTypeId)
          .ValidateCredentials(request.Credentials))
      );

      Result<User>? success = results.FirstOrDefault(result => result.IsSuccess);
      if (success is null)
        return Result.Failure<IdentityResponseDto>(ResultTypes.ValidationError, [new Error("Domain.Error", "No se encontraron credenciales válidas.")]);

      return await Task.FromResult(success).Map(result => _tokenProvider.GenerateToken(result, request.ApplicationId));
    }
    else
      return await _provider.GetRequiredKeyedService<ICredentialValidatorService>((CredentialTypes)request.CredentialType)
        .ValidateCredentials(request.Credentials)
        .Map(result => _tokenProvider.GenerateToken(result, request.ApplicationId));
  }
}
