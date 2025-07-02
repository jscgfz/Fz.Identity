using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Users.Queries.Users;

public sealed record UsersQuery(
  int? ApplicationId,
  string? Filter,
  int? PageIndex,
  int? PageSize,
  string? FullNameShort,
  string? Email,
  string? Rol,
  bool? IsActive,
  DateTime? DateFrom,
  DateTime? DateTo,
  bool FullSet = false
) : PaginationParams(PageIndex, PageSize, FullSet), IQuery<Result<IPaginatedResult<UserDto>>>;
