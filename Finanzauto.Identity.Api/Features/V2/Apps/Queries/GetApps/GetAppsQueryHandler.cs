using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Common;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApps;

public sealed class GetAppsQueryHandler(IServiceProvider provider) : IQueryHandler<GetAppsQuery, IPaginatedResult<AppDetailsDto>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public Task<Result<IPaginatedResult<AppDetailsDto>>> Handle(GetAppsQuery request, CancellationToken cancellationToken)
    => SpecificationResolver.ComputeResult(
      AppSpecifications.ByFilter,
      request,
      _context,
      [new Error("Apps.NotFonud", "Aplicaciones no encontradas")]
    );
}
