using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Features.Reports.Dtos;
using Fz.Identity.Api.Features.Reports.Specifications;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Reports.Queries.FullLoginReport;

public sealed class FullLoginReportQueryHandler(IServiceProvider provider) : IQueryHandler<FullLoginReportQuery, Result<IPaginatedResult<LoginLogDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public Task<Result<IPaginatedResult<LoginLogDto>>> Handle(FullLoginReportQuery request, CancellationToken cancellationToken)
    => SpecificationResolver.ComputeResult(
      LoginReportSpecifications.ByFilter,
      request,
      _context,
      [new Error("Logs.NotFound", "No se encontraron logs en el sistema")]
    );
}
