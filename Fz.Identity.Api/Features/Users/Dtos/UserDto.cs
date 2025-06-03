using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record UserDto(
  Guid Id,
  string Name,
  string Surname,
  string? IdentificationNumber,
  string Email,
  bool? IsActive,
  IEnumerable<RoleDto>? Roles
)
{
  public static UserDto MapFrom(User user)
    => new UserDto(
        user.Id,
        user.Name,
        user.Surname,
        user.IdentificationNumber,
        user.PrincipalEmail,
        user.IsDeleted,
        (user.Roles.Any() ? user.Roles.Select(r => new RoleDto(r.RoleId, r.Role.Name, null)) : null)
      );
}
