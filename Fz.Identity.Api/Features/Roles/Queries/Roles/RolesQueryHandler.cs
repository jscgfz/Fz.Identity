using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Roles.Queries.Roles;

public sealed class RolesQueryHandler(IServiceProvider provider) : IQueryHandler<RolesQuery, Result<IEnumerable<RoleDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public Task<Result<IEnumerable<RoleDto>>> Handle(RolesQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
    => Result.From(
        _context.Repository<Role>()
          .Where(row => request.ApplicationId == null || row.ApplicationId == request.ApplicationId)
          .Select(row => new RoleDto(row.Id, row.Name, row.ApplicationId))
          .ToListAsync(cancellationToken),
        ResultTypes.NotFound,
        [new Error("roles not found", "no se encontraron roles")]
      ).Map(result => result.AsEnumerable());
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
