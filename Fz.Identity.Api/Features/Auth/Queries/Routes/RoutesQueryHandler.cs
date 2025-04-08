using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Auth.Queries.Routes;

public sealed class RoutesQueryHandler(IServiceProvider provider) : IQueryHandler<RoutesQuery, Result<IEnumerable<RouteDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

  public Task<Result<IEnumerable<RouteDto>>> Handle(RoutesQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
    => Result.From(
        _context.Repository<RoleRoute>().Where(row => _identityManager.RoleIds.Contains(row.RoleId))
          .Include(row => row.Route).ToListAsync(cancellationToken),
        ResultTypes.NotFound,
        [new Error("Routes.NotFound", "no se encontraron rutas para el usuario")]
      )
    .Map(result => RouteDto.MapFrom(result, null));
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
