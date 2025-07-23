using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Roles.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Roles.Queries.GetRoles;

public sealed record GetRolesQuery(
  int? PageIndex,
  int? PageSize,
  string? Filter,
  bool FullSet = false
) : IPaginationParams, IQuery<IPaginatedResult<RoleDto>>;
