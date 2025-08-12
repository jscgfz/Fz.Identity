using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Masters.Queries.Areas;

public sealed class AreasQueryHandler(IServiceProvider provider) : IQueryHandler<AreasQuery, Result<IEnumerable<AreaDto>>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  public Task<Result<IEnumerable<AreaDto>>> Handle(AreasQuery request, CancellationToken cancellationToken)
  => Result.From(
        _context.Repository<Area>().Select(row => new AreaDto(row.Id, row.Name)).ToListAsync(cancellationToken),
        ResultTypes.NotFound,
        [new Error("Areas not found", "no se encontraron areas")]
      )
    .Map(v => v.AsEnumerable());
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
