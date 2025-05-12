using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Users.Queries.UserById;

public sealed class UserQueryHandler(IServiceProvider provider) : IQueryHandler<UserQuery, Result<UserDetailDto>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public Task<Result<UserDetailDto>> Handle(UserQuery request, CancellationToken cancellationToken)
  => Result.From(
      _context.Repository<User>().Where(row => row.Id == request.userId)
        .Include(row => row.Roles.Where(r => r.Role.ApplicationId == _identityManager.ApplicationId))
        .ThenInclude(ur => ur.Role)
        .FirstOrDefaultAsync(),
      ResultTypes.NotFound,
      [new Error("Users.NotFound", "no se encontraron usuarios para la consulta")]
    ).Map(UserDetailDto.MapFrom);
}
