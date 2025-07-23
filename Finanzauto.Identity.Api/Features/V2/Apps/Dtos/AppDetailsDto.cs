namespace Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

public sealed record AppDetailsDto(
  Guid Id,
  string Name,
  string? Description,
  bool MultiDomainEnabled,
  bool RootApplicationEnabled,
  bool TwoFactorAuthenticationEnabled,
  AppSecurityDetailsDto? Safety
);
