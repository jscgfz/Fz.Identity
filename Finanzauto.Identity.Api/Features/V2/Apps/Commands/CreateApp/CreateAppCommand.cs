using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Commands.CreateApp;

public sealed record CreateAppCommand(
  string Name,
  string? Description,
  string Prefix,
  string? DomainName,
  bool MultiDomainEnabled,
  bool RootAppEnabled,
  bool TwoFactorAuthenticationEnabled,
  TimeSpan? TokenExpirationTime,
  TimeSpan? RefreshTokenExpirationTime
) : ICommand<AppCreatedDto>;

