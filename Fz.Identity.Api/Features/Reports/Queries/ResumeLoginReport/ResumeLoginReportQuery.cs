using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Reports.Dtos;

namespace Fz.Identity.Api.Features.Reports.Queries.ResumeLoginReport;

public sealed record ResumeLoginReportQuery(
  DateTime? StartDate,
  DateTime? EndDate,
  int? ApplicationId,
  Guid? UserId
) : IQuery<Result<IEnumerable<LoginResumeDto>>>;
