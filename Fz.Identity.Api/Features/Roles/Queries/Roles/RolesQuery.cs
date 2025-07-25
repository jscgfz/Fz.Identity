using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Roles.Queries.Roles;

public sealed record RolesQuery(
  int? ApplicationId,
  DateTime? DateFrom,
  DateTime? DateTo,
  string? Name,
  string? SIManagementStatus,
  string? TIManagementStatus,
  int? PageIndex,
  int? PageSize,
  bool FullSet = false
  ) : PaginationParams(PageIndex, PageSize, FullSet), IQuery<Result<IPaginatedResult<RoleDto>>>;
