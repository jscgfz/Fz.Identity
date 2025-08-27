using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Roles.Queries.ActiveDirectoryRoles;

public sealed class ActiveDirectoryRolesQueryHandler(IServiceProvider provider) : IQueryHandler<ActiveDirectoryRolesQuery, Result<IEnumerable<ActiveDirectoryRoleDto>>>
{
  private readonly IDbContext _context
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  private readonly ILDAPService _ldapService
    = provider.GetRequiredService<ILDAPService>();
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);

  public async Task<Result<IEnumerable<ActiveDirectoryRoleDto>>> Handle(ActiveDirectoryRolesQuery request, CancellationToken cancellationToken)
  {
    Application? applicacion = await _context.Repository<Application>().FirstOrDefaultAsync(a => a.Id == _identityManager.ApplicationId);
    if (applicacion == null)
      return Result.Failure<IEnumerable<ActiveDirectoryRoleDto>>(ResultTypes.NotFound, [new Error("Application.NotFound - No se encontró la aplicación")]);

    var activeDirectoryRoles = await _context.Repository<ActiveDirectoryRole>().Where(adr => adr.ApplicationId == _identityManager.ApplicationId).ToListAsync();
    var ldapResponse = await _ldapService.GetRolesByApp(applicacion.Alias);
    if (activeDirectoryRoles == null && ldapResponse == null)
      return Result.Failure<IEnumerable<ActiveDirectoryRoleDto>>(ResultTypes.NotFound, [new Error("ActiveDirectoryRole.NotFound - No se encontraron roles del directorio activo")]);

    if (ldapResponse != null && ldapResponse.Roles.Any())
    {
      var ldapRoles = ldapResponse.Roles.Select(a => a.Name);
      var newRoles = ldapRoles.Where(r => !activeDirectoryRoles.Any(adr => adr.Name == r));
      if (newRoles.Any())
      {
        List<ActiveDirectoryRole> newActiveDirectoryRoles = new();
        foreach (var role in newRoles)
        {
          ActiveDirectoryRole activeDirectoryRole = new()
          {
            Id = Guid.NewGuid(),
            Name = role,
            ApplicationId = (int)_identityManager.ApplicationId,
          };
          newActiveDirectoryRoles.Add(activeDirectoryRole);
        }
        _context.AddRange(newActiveDirectoryRoles);
      }
      var rolesToDelete = activeDirectoryRoles.Where(adr => !ldapRoles.Any(r => r == adr.Name));
      if (rolesToDelete.Any())
        _context.DeleteRange(rolesToDelete);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
      activeDirectoryRoles = await _context.Repository<ActiveDirectoryRole>().Where(adr => adr.ApplicationId == _identityManager.ApplicationId).ToListAsync();
    }

    var roles = await _context.Repository<Role>().Where(r => r.ApplicationId == _identityManager.ApplicationId)
      .Include(r => r.ActiveDirectoryRole)
      .ToListAsync();

    var avalaibleRoles = activeDirectoryRoles.Except(roles.Select(r => r.ActiveDirectoryRole));
    if (request.IncludeId.HasValue)
      avalaibleRoles = avalaibleRoles.Append(roles.FirstOrDefault(r => r.ActiveDirectoryRoleId == request.IncludeId).ActiveDirectoryRole);

    return Result.Success(avalaibleRoles.Select(row => new ActiveDirectoryRoleDto(row.Id, row.Name)));
  }
}
