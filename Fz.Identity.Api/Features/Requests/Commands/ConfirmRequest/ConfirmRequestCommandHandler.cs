using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Roles.Commands.AddRole;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Fz.Identity.Api.Features.Requests.Commands.ConfirmRequest;

public class ConfirmRequestCommandHandler(IServiceProvider provider) : ICommandHandler<ConfirmRequestCommand, Result>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result> Handle(ConfirmRequestCommand request, CancellationToken cancellationToken)
  {
    var requestEntity = await _dbContext.Repository<Request>().Where(r => r.Id == request.RequestId && r.StatusId == (int)RequestStatuses.Approved && r.RequiresConfirmation).FirstOrDefaultAsync(cancellationToken);

    if (requestEntity is null)
      return Result.Failure(type: ResultTypes.NotFound, [new Error("Request.NotFound", "No se encontró la solicitud")]);

    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    var requestedChanges = JsonSerializer.Deserialize<AddRoleCommand>(requestEntity.ChangesJson, options);
    var requestedPermissionIds = requestedChanges.Modules.SelectMany(m => m.Actions).SelectMany(a => a.Permissions.Where(p => p.Enabled)).Select(p => p.Id).ToList();

    IEnumerable<RoleClaim> permissions = await _dbContext.Repository<RoleClaim>().Where(rc => rc.RoleId == requestEntity.RoleId)
      .IncludeDeleted()
      .ToListAsync(cancellationToken);

    IEnumerable<RoleClaim> roleClaimsToDelete = permissions.Where(rc => !requestedPermissionIds.Contains(rc.ClaimId));
    if (roleClaimsToDelete.Any())
      _dbContext.DeleteRange(roleClaimsToDelete);

    List<RoleClaim> roleClaimsToUpdate = permissions.Where(rc => requestedPermissionIds.Contains(rc.ClaimId) && rc.IsDeleted).ToList();

    if (roleClaimsToUpdate.Any())
    {
      roleClaimsToUpdate.ForEach(ur => ur.IsDeleted = false);
      _dbContext.UpdateRange(roleClaimsToUpdate);
    }

     IEnumerable<int> newPermissionIds = requestedPermissionIds.Except(permissions.Select(ur => ur.ClaimId));
    if (newPermissionIds.Any())
    {
      List<RoleClaim> newRoleClaims = new();
      foreach (var claimId in newPermissionIds)
      {
        RoleClaim roleClaim = new()
        {
          RoleId = requestEntity.RoleId,
          ClaimId = claimId,
        };
        newRoleClaims.Add(roleClaim);
      }
      _dbContext.AddRange(newRoleClaims);
    }
    requestEntity.RequiresConfirmation = false;

    Role role = await _dbContext.Repository<Role>().FirstOrDefaultAsync(r => r.Id == requestEntity.RoleId);
    role.Name = requestedChanges.Name;
    role.ActiveDirectoryRoleId = requestedChanges.ActiveDirectoryRoleId;
    await _unitOfWork.SaveChangesAsync();

    AuditLog auditLog = new AuditLog
    {
      Action = Actions.Edit,
      Module = "Gestión de roles",
      UserId = _identityManager.CurrentUserId,
      ApplicationId = (int)_identityManager.ApplicationId,
      Description = $"Confirmación de edición rol {requestEntity.Role.Name}",
      Entity = "request",
      EntityId = requestEntity.Id.ToString()
    };
    _dbContext.Add(auditLog);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
