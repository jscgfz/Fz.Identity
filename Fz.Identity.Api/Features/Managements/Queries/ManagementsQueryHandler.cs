using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Features.Managements.Dtos;
using Fz.Identity.Api.Features.Users;
using Fz.Identity.Api.Settings;
using MediatR;

namespace Fz.Identity.Api.Features.Managements.Queries;

public class ManagementsQueryHandler(IServiceProvider provider) : IQueryHandler<ManagementsQuery, Result<IPaginatedResult<ManagementDto>>>
{
  private readonly IReadOnlyDbContext _context
   = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  public Task<Result<IPaginatedResult<ManagementDto>>> Handle(ManagementsQuery request, CancellationToken cancellationToken)
   => SpecificationResolver.ComputeResult(
        ManagementSpecifications.ByManagementsQuery,
        request,
        _context,
        [new Error("Managements.NotFound", "no se encontraron gestiones para la consulta")]
      );
}
