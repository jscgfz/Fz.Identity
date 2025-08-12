using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Roles.Commands.AddRole;

public sealed class AddRoleCommandHandler(IServiceProvider provider) : ICommandHandler<AddRoleCommand, Result>
{
  private readonly IDbContext _dbContext
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

  public async Task<Result> Handle(AddRoleCommand request, CancellationToken cancellationToken)
  {
    IEnumerable<KeyValuePair<Error, bool>> validations = [
      KeyValuePair.Create(
        new Error("Name.Registered", "El nombre ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<Role>().AnyAsync(row => row.Name == request.Name && row.ApplicationId == _identityManager.ApplicationId, cancellationToken)),
      KeyValuePair.Create(
        new Error("ActiveDirectoryName.Registered", "El nombre de directorio activo ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<Role>().AnyAsync(row => row.ActiveDirectoryRoleId == request.ActiveDirectoryRoleId && row.ApplicationId == _identityManager.ApplicationId, cancellationToken)),
    ];

    if (validations.Any(row => row.Value))
      return Result.Failure(ResultTypes.BadRequest, validations.Where(row => row.Value).Select(row => row.Key));

    Role role = new()
    {
      Name = request.Name,
      ActiveDirectoryRoleId = request.ActiveDirectoryRoleId,
      ApplicationId = (int)_identityManager.ApplicationId,
    };

    _dbContext.Add(role);
    await _unitOfWork.SaveChangesAsync();

    var permissions = request.Modules.SelectMany(m => m.Actions)
      .SelectMany(a => a.Permissions)
      .Where(p => p.Enabled)
      .ToList();
    List<RoleClaim> roleClaims = [];
    foreach (var permission in permissions)
    {
      roleClaims.Add(new RoleClaim(role.Id, permission.Id));
    }
    _dbContext.AddRange(roleClaims);
    await _unitOfWork.SaveChangesAsync();
    return Result.Success();
  }
}
