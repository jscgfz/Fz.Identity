using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Managements.Dtos;

namespace Fz.Identity.Api.Features.Managements.Queries;

public sealed record class ManagementsQuery(
  string? User,
  string? Module,
  string? Action,
  DateTime? DateFrom,
  DateTime? DateTo,
  int? ApplicationId,
  int? PageIndex,
  int? PageSize,
  bool FullSet = false
  ) : PaginationParams(PageIndex, PageSize, FullSet), IQuery<Result<IPaginatedResult<ManagementDto>>>;