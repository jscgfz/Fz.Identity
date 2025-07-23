namespace Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

public sealed record TokenResponseDto(
  string AccessToken,
  UserIdentityDto User
);
