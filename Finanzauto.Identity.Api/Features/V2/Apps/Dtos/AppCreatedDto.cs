namespace Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

public sealed record AppCreatedDto(
  Guid Id,
  byte[] SignatureKey,
  TimeSpan TokenExpirationTime,
  TimeSpan RefreshTokenExpirationTime
);
