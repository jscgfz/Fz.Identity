using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Abstractions.Managers.Identity;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Models.Managers.Identity.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Managers.Identity;

public sealed class RoleManager(IServiceProvider provider) : IRoleManager
{
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();

  public async Task<Result<Unit>> Configure(RolConfigurationRequest request, CancellationToken cancellationToken)
  {
    if(!await _context.Repository<User>().AnyAsync(row => row.Id == request.UserId, cancellationToken))
      return Result.Failure<Unit>(
        StatusCodes.Status404NotFound,
        new Error("User.NotFound", "El usuario no existe")
      );

    if(request.Adds is IEnumerable<Guid> adds && adds.Any())
    {
      if(await _context.Repository<UserRole>().AnyAsync(row => row.UserId == request.UserId && adds.Contains(row.RoleId), cancellationToken))
        return Result.Failure<Unit>(
          StatusCodes.Status409Conflict,
          new Error("Role.AlreadyExists", "El rol ya está asignado al usuario")
        );

      IEnumerable<UserRole> RoleAdds = adds.Select(roleId => new UserRole
      {
        UserId = request.UserId,
        RoleId = roleId
      });

      _context.AddRange(RoleAdds);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    if (request.Removes is IEnumerable<Guid> removes && removes.Any())
    {
      if (!await _context.Repository<UserRole>().AnyAsync(row => row.UserId == request.UserId && removes.Contains(row.RoleId), cancellationToken))
        return Result.Failure<Unit>(
          StatusCodes.Status404NotFound,
          new Error("Role.NotFound", "El rol no está asignado al usuario")
        );
      
      IEnumerable<UserRole> RoleRemoves = await _context.Repository<UserRole>()
        .Where(row => row.UserId == request.UserId && removes.Contains(row.RoleId))
        .ToListAsync(cancellationToken);

      _context.DeleteRange(RoleRemoves);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    return Result.Unit;
  }
}
