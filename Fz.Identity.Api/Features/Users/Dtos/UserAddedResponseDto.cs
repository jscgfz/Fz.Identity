namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record UserAddedResponseDto(
  Guid Id,
  string UserName
);
