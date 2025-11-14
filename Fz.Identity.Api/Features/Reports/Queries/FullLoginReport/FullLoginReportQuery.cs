using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Reports.Dtos;

namespace Fz.Identity.Api.Features.Reports.Queries.FullLoginReport;

public sealed record FullLoginReportQuery(
  DateTime? StartDate,
  DateTime? EndDate,
  int? ApplicationId,
  Guid? UserId,
  int? PageIndex,
  int? PageSize,
  bool FullSet = false
) : IQuery<Result<IPaginatedResult<LoginLogDto>>>, IPaginationParams;
