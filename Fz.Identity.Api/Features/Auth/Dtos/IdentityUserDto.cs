namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record IdentityUserDto(
  Guid Id,
  string Name,
  string Surname,
  string Username,
  string PrincipalEmail,
  bool PrincipalEmailConfirmed,
  string PrincipalPhoneNumber,
  bool PrincipalPhoneNumberConfirmed,
  DateTime IssuedAt,
  DateTime ExpiresAt,
  ApplicationIdentityDto Application
);
