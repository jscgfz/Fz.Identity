using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Auth.Commands.Login;

public sealed class LoginCommandHandler(IServiceProvider provider) : ICommandHandler<LoginCommand, Result<IdentityResponseDto>>
{
  private readonly IServiceProvider _provider = provider;
  private readonly ITokenProviderService _tokenProvider = provider.GetRequiredKeyedService<ITokenProviderService>(ContextTypes.Identity);

  public Task<Result<IdentityResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    => _provider.GetRequiredKeyedService<ICredentialValidatorService>((CredentialTypes)request.CredentialType)
      .ValidateCredentials(request.Credentials)
      .Map(result => _tokenProvider.GenerateToken(result, request.ApplicationId));
}
