using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public sealed record RoleDetailDto(
  Guid Id,
  string Name,
  string SIManagementStatus,
  string? ActiveDirectoryRoleName,
  int? RequestId,
  IEnumerable<ModuleDto>? Modules,
  Guid? ActiveDirectoryRoleId
  )
{
  public static RoleDetailDto MapFrom(Role role, IEnumerable<Claim> claims, Request? request)
    => new(
      role.Id,
      role.Name,
      request == null || (!request.RequiresConfirmation && request.StatusId == (int)RequestStatuses.Approved) ? ManagementRequestStatuses.Without : request.Status.Name,
      role.ActiveDirectoryRole.Name,
      request == null || (!request.RequiresConfirmation && request.StatusId == (int)RequestStatuses.Approved) ? null : request.Id,
      ModuleDto.MapFrom(claims, role.Id),
      role.ActiveDirectoryRoleId
      );
}
