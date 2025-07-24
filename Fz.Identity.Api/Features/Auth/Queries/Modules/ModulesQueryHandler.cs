using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Route = Fz.Identity.Api.Database.Entities.Route;

namespace Fz.Identity.Api.Features.Auth.Queries.Modules;

public sealed class ModulesQueryHandler(IServiceProvider provider) : IQueryHandler<ModulesQuery, Result<IEnumerable<ModuleDto>>>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result<IEnumerable<ModuleDto>>> Handle(ModulesQuery request, CancellationToken cancellationToken)
  => Result.From(
       await _dbContext.Repository<Claim>().Where(row => row.Module.ApplicationId == _identityManager.ApplicationId)
          .Include(row => row.Module)
          .Include(row => row.Action)
          .Include(row => row.Parent)
          .ToListAsync(cancellationToken),
        ResultTypes.NotFound,
        [new Error("Modules.NotFound", "no se encontraron modulos para la aplicacion")]
      ).Map(result => ModuleDto.MapFrom(result, null));
}
