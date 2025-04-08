using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Masters.Queries.Applications;

public sealed class ApplicationsQueryHandler(IServiceProvider provider) : IQueryHandler<ApplicationsQuery, Result<IEnumerable<ApplicationDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public Task<Result<IEnumerable<ApplicationDto>>> Handle(ApplicationsQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
    => Result.From(
      _context.Repository<Application>().Select(row => new ApplicationDto(row.Id, row.Name)).ToListAsync(cancellationToken),
      ResultTypes.NotFound,
      [new Error("Applications.NotFound")]
    )
    .Map(result => result.AsEnumerable());
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
