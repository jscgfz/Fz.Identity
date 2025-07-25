using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public sealed record RoleDto(
  Guid Id,
  string Name,
  string? CreatedDate,
  int? ApplicationId,
  string? SIManagementStatus,
  string? TiManagementStatus,
  string? RemainingTime
  ) : MasterDto<Guid>(Id, Name)
{
  public RoleDto(Guid Id, string Name, int? ApplicationId) : this(Id, Name, null, ApplicationId, null, null, null) { }
}
