namespace Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

public sealed record UserIdentityDto(
  Guid Id,
  string Name,
  string Surname,
  string PrincipalEmail,
  string? PrincipalPhoneNumber,
  DateTime IssuedAt,
  DateTime ExpiresAt,
  ApplicationIdentityDto Application
);
