using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Roles;

public sealed class RoleSpecifications
{
  public static ISpecification<RoleWithRequestDto, RoleDto> ByRolesQuery(RolesQuery query)
    => new Specification<RoleWithRequestDto, RoleDto>()
    .WithFilter(row => string.IsNullOrEmpty(query.Name) || row.Role.Name.Contains(query.Name))
    .WithAndFilter(row => (!query.DateFrom.HasValue || row.Role.CreatedAtUtc.Date >= query.DateFrom.Value.Date) && (!query.DateTo.HasValue || row.Role.CreatedAtUtc.Date <= query.DateTo.Value.Date))
    .WithAndFilter(row => string.IsNullOrEmpty(query.SIManagementStatus) || row.Request.Status.Name.Contains(query.SIManagementStatus))
    .WithSelect(row => new(
      row.Role.Id,
      row.Role.Name,
      row.Role.CreatedAtUtc.ToString("dd/MM/yyyy hh:mm tt"),
      row.Role.ApplicationId,
      row.Request == null || (!row.Request.RequiresConfirmation && row.Request.StatusId == (int)RequestStatuses.Approved) ? ManagementRequestStatuses.Without : row.Request.Status.Name,
      row.Request.RequiresConfirmation ? ManagementRequestStatuses.Pending : ManagementRequestStatuses.DoesNotApply,
      row.Request == null ? null : RequestDetailDto.GettRemainingTime(row.Request.ExpireAt)
      ));
}
