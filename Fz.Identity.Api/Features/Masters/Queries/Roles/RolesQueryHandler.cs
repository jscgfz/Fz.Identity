using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Core.Result;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Features.Masters.Queries.Areas;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Fz.Core.Persistence.Abstractions;
using Fz.Identity.Api.Settings;
using Fz.Core.Result.Extensions;

namespace Fz.Identity.Api.Features.Masters.Queries.Roles;

public sealed class RolesQueryHandler(IServiceProvider provider) : IQueryHandler<RolesQuery, Result<IEnumerable<RoleMasterDto>>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  public Task<Result<IEnumerable<RoleMasterDto>>> Handle(RolesQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
    => Result.From(
        _context.Repository<Role>().Where(r => request.ApplicationId == null || r.ApplicationId == request.ApplicationId).Select(row => new RoleMasterDto(row.Id, row.Name)).ToListAsync(cancellationToken),
        ResultTypes.NotFound,
        [new Error("Areas not found", "no se encontraron areas")]
      ).Map(v => v.AsEnumerable());
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
