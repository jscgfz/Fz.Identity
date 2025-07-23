using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Common;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Queries.Values;

public sealed class ClaimValuesQueryHandler(IServiceProvider provider) : IQueryHandler<ClaimValuesQuery, IPaginatedResult<FullClaimDto>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public Task<Result<IPaginatedResult<FullClaimDto>>> Handle(ClaimValuesQuery request, CancellationToken cancellationToken)
    => SpecificationResolver.ComputeResult(
      ClaimsSpecifications.ByFilter,
      request,
      _context,
      [new Error("Claims.NotFound", "No se han encontrado valores de permisos")]
    );
}
