using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Requests.Queries.Requests;

public sealed class RequestsQueryHandler(IServiceProvider provider) : IQueryHandler<RequestsQuery, Result<IPaginatedResult<RequestDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  public Task<Result<IPaginatedResult<RequestDto>>> Handle(RequestsQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
  => SpecificationResolver.ComputeResult(
    RequestSpecification.ByRequestsQuery,
    request,
    _context,
    [new Error("Requests.NotFound", "no se encontraron solicitudes para la consulta")]
    );
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
