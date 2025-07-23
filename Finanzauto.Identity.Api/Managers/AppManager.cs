using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Models.Apps.Dtos;
using Finanzauto.Identity.Api.Models.Roles.Dto;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Managers;

public sealed class AppManager(IServiceProvider provider) : IAppManager
{
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();

  public async Task<Result<IEnumerable<UserAppResumeDto>>> UserInfo(Guid userId, CancellationToken cancellationToken)
  {
    IEnumerable<UserAppResumeDto> apps = await _context.Repository<UserRole>()
      .AsNoTracking()
      .Include(row => row.Role)
      .ThenInclude(row => row.App)
      .Where(row => row.UserId == userId)
      .GroupBy(row => row.Role.App)
      .Select(group => new UserAppResumeDto
      (
        group.Key.Id,
        group.Key.ApplicationName,
        group.Key.Description,
        group.Select(role => new RoleResumeDto(role.Role.Id, role.Role.Name, role.Role.Description))
      ))
      .ToListAsync(cancellationToken);

    return apps.Any()
      ? Result.Success(apps)
      : Result.Failure<IEnumerable<UserAppResumeDto>>(
        StatusCodes.Status404NotFound,
        new Error("User.Apps.NotFound", "No se encontraron aplicaciones asociadas al usuario.")
      );
  }
}
