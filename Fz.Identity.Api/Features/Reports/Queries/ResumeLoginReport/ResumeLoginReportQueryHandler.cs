using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Features.Reports.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Reports.Queries.ResumeLoginReport;

public sealed class ResumeLoginReportQueryHandler(IServiceProvider provider) : IQueryHandler<ResumeLoginReportQuery, Result<IEnumerable<LoginResumeDto>>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public Task<Result<IEnumerable<LoginResumeDto>>> Handle(ResumeLoginReportQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
