namespace Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

public sealed record AppSecurityDetailsDto(
  string ApiKeyPrefix,
  string? DomainName,
  byte[]? SignatureKey,
  TimeSpan TokenExpirationTime,
  TimeSpan RefreshTokenExpirationTime
);
