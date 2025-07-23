using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;

public sealed class LoginCommandHandler(IServiceProvider provider) : ICommandHandler<LoginCommand, TokenResponseDto>
{
  private readonly ICredentialResolverManager _credentialResolver = provider.GetRequiredService<ICredentialResolverManager>();
  private readonly ITokenProviderManager _tokenManager = provider.GetRequiredService<ITokenProviderManager>();

  public Task<Result<TokenResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    => _credentialResolver
      .ResolveCredential(request, cancellationToken)
      .Bind(result => _tokenManager.FromResolution(result, cancellationToken));
}
