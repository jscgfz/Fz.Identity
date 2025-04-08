namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record IdentityResponseDto(
  string AccessToken,
  IdentityUserDto User
);
