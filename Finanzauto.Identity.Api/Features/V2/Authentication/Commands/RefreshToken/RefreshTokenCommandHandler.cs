using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Authentication.Commands.RefreshToken;

public sealed class RefreshTokenCommandHandler(IServiceProvider provider) : ICommandHandler<RefreshTokenCommand, TokenResponseDto>
{
  private readonly ITokenProviderManager _token = provider.GetRequiredService<ITokenProviderManager>();
  public Task<Result<TokenResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    => _token.Refresh(cancellationToken);
}
