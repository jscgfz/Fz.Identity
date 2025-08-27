using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Roles.Queries.RoleById;

public sealed class RoleByIdQueryHandler(IServiceProvider provider) : IQueryHandler<RoleByIdQuery, Result<RoleDetailDto>>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result<RoleDetailDto>> Handle(RoleByIdQuery request, CancellationToken cancellationToken)
  {
    var role = await _dbContext.Repository<Role>().Where(r => r.Id == request.Id)
      .Include(r => r.ActiveDirectoryRole)
      .FirstOrDefaultAsync(cancellationToken);

    if (role is null)
      return Result.Failure<RoleDetailDto>(type: ResultTypes.NotFound, [new Error("Role.NotFound", "No se encontró el rol")]);

    var roleClaims = await _dbContext.Repository<RoleClaim>().Where(rc => rc.RoleId == request.Id)
      .Include(rc => rc.Claim)
        .ThenInclude(c => c.Module)
      .Include(rc => rc.Claim)
        .ThenInclude(c => c.Action)
      .Include(rc => rc.Claim)
        .ThenInclude(c => c.RoleClaims)
      .Select(rc => rc.Claim)
      .ToListAsync();

    var moduleIds = roleClaims.Select(c => c.ModuleId).Distinct();

    var claimsQuery = _dbContext.Repository<Claim>();
    if (!request.IncludeAllModules)
      claimsQuery = claimsQuery.Where(c => moduleIds.Contains(c.ModuleId));

      var claims = await claimsQuery.Where(c => c.Module.ApplicationId == _identityManager.ApplicationId)
      .Include(c => c.Module)
      .Include(c => c.Action)
      .Include(c => c.RoleClaims)
      .ToListAsync();

    var modules = roleClaims.Concat(claims.Where(c => !roleClaims.Any(rc => rc.Id == c.Id))).ToList();

    Request requestEntity = await _dbContext.Repository<Request>().Where(r => r.RoleId == role.Id)
      .OrderByDescending(r => r.Id)
      .Include(r => r.Status)
      .FirstOrDefaultAsync(); 

    return Result.Success(RoleDetailDto.MapFrom(role, modules, requestEntity));
  }
}
