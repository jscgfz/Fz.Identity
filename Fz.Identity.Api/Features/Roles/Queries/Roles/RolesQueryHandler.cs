using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Error = Fz.Core.Result.Error;

namespace Fz.Identity.Api.Features.Roles.Queries.Roles;

public sealed class RolesQueryHandler(IServiceProvider provider) : IQueryHandler<RolesQuery, Result<IPaginatedResult<RoleDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public async Task<Result<IPaginatedResult<RoleDto>>> Handle(RolesQuery request, CancellationToken cancellationToken)
  {
    var q = _context.Repository<Role>().Where(r => request.ApplicationId == null || r.ApplicationId == request.ApplicationId)
      .GroupJoin(
      _context.Repository<Request>().Where(r => request.ApplicationId == null || r.ApplicationId == request.ApplicationId)
      .Include(r => r.Status),
      role => role.Id,
      requestEntity => requestEntity.ResourceId,
      (role, requests) => new RoleWithRequestDto
      {
          Role = role,
          Request = requests.OrderByDescending(r => r.Id).FirstOrDefault()
        }
      );

    IQueryable<RoleDto> query = RoleSpecifications.ByRolesQuery(request).Apply(q);
    int count = await query.CountAsync();
    int pageCount = (int)Math.Ceiling((double)count / (request.PageSize ?? 10));
    if (!request.FullSet)
      query = query
      .Skip(((request.PageIndex ?? 1) - 1) * (request.PageSize ?? 10))
      .Take(request.PageSize ?? 10);
    var data = await query.ToListAsync();
    IPaginatedResult<RoleDto> result = new PaginationSet<RoleDto>(data, pageCount, request.PageIndex ?? 1, request.PageSize ?? 10, count);

    return result.Data.Any() ? Result.Success(result) : Result.Failure<IPaginatedResult<RoleDto>>(type:ResultTypes.NotFound, [new Error("Roles.NotFound", "no se encontraron roles para la consulta")]);
  }
}
