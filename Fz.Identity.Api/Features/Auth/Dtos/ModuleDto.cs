using Fz.Identity.Api.Features.Masters.Dtos;
using Claim = Fz.Identity.Api.Database.Entities.Claim;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record ModuleDto(
  int Id,
  string Name,
  IEnumerable<SubmoduleDto>? Actions
  )
{
  public static IEnumerable<ModuleDto> MapFrom(IEnumerable<Claim> claims, Guid? roleId)
  {
    var claimsWithParent = claims
    .Where(c => c.Module.Parent != null)
    .Select(c => new {
      ParentId = c.Module.Parent.Id,
      ParentName = c.Module.Parent.Name,
      SubId = c.Module.Id,
      SubName = c.Module.Name,
      PermissionId = c.Id,
      ActionName = c.Action.Name,
      PermissionEnbaled = roleId.HasValue && c.RoleClaims.Any(rc => rc.RoleId == roleId),
      Order = c.Order
    });

    var claimsWithoutParent = claims
        .Where(c => c.Module.Parent == null)
        .Select(c => new {
          ParentId = c.Module.Id,
          ParentName = c.Module.Name,
          SubId = c.Module.Id,
          SubName = c.Module.Name,
          PermissionId = c.Id,
          ActionName = c.Action.Name,
          PermissionEnbaled = roleId.HasValue && c.RoleClaims.Any(rc => rc.RoleId == roleId),
          Order = c.Order
        });

    var allClaims = claimsWithParent.Concat(claimsWithoutParent);

    var result = allClaims
        .GroupBy(c => new { c.ParentId, c.ParentName })
        .Select(parentGroup => new ModuleDto
        (
          parentGroup.Key.ParentId,
          parentGroup.Key.ParentName,
          parentGroup
                .GroupBy(c => new { c.SubId, c.SubName })
                .Select(subGroup => new SubmoduleDto
                (
                  subGroup.Key.SubId,
                  subGroup.Key.SubName,
                  subGroup.Select(c => new PermissionDto
                  (
                    c.PermissionId,
                    c.ActionName,
                    c.PermissionEnbaled,
                    c.Order
                  ))
                .OrderBy(dto => dto.Order)
                .ToList()
                )).ToList()
        )).ToList();

    return result;
  }
}