using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Authentication.Commands.RefreshToken;

public sealed record RefreshTokenCommand : ICommand<TokenResponseDto>
{
  private RefreshTokenCommand() { }
  public static RefreshTokenCommand Instance { get; } = new();
}
