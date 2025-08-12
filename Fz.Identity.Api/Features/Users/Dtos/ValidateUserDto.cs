namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record ValidateUserDto(
  string RoleName,
  Guid RoleId,
  bool HasArea
  );
