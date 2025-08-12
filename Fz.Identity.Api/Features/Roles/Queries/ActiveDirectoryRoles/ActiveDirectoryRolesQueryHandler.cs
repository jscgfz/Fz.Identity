using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Roles.Queries.ActiveDirectoryRoles;

public sealed class ActiveDirectoryRolesQueryHandler(IServiceProvider provider) : IQueryHandler<ActiveDirectoryRolesQuery, Result<IEnumerable<ActiveDirectoryRoleDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result<IEnumerable<ActiveDirectoryRoleDto>>> Handle(ActiveDirectoryRolesQuery request, CancellationToken cancellationToken)
  {
    var activeDirectoryRoles = await _context.Repository<ActiveDirectoryRole>().Where(adr => adr.ApplicationId == _identityManager.ApplicationId).ToListAsync();
    if (activeDirectoryRoles == null)
      return Result.Failure<IEnumerable<ActiveDirectoryRoleDto>>(ResultTypes.NotFound, [new Error("ActiveDirectoryRole.NotFound - No se encontraron roles del directorio activo")]);

    var roles = await _context.Repository<Role>().Where(r => r.ApplicationId == _identityManager.ApplicationId)
      .Include(r => r.ActiveDirectoryRole)
      .ToListAsync();

    var avalaibleRoles = activeDirectoryRoles.Except(roles.Select(r => r.ActiveDirectoryRole));
    if (request.IncludeId.HasValue)
      avalaibleRoles = avalaibleRoles.Append(roles.FirstOrDefault(r => r.ActiveDirectoryRoleId == request.IncludeId).ActiveDirectoryRole);

    return Result.Success(avalaibleRoles.Select(row => new ActiveDirectoryRoleDto(row.Id, row.Name)));
  }
}
