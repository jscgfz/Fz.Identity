using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record UserDto(
  Guid Id,
  string Name,
  string Surname,
  string IdentificationNumber,
  string Email,
  bool IsDeleted,
  IEnumerable<RoleDto>? Roles
);
