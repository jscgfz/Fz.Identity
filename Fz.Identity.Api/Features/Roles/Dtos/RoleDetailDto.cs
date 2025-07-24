using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public sealed record RoleDetailDto(
  Guid Id,
  string Name,
  string? ActiveDirectoryName,
  IEnumerable<ModuleDto>? Modules
  )
{
  public static RoleDetailDto MapFrom(Role role, IEnumerable<Claim> claims)
    => new(
      role.Id,
      role.Name,
      role.ActiveDirectoryName,
      ModuleDto.MapFrom(claims, role.Id)
      );
}
