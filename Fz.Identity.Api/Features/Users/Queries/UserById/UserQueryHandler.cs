using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Abstractions.Services;
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
  private readonly IAlfrescoService _alfresco
    = provider.GetRequiredService<IAlfrescoService>();
  public async Task<Result<UserDetailDto>> Handle(UserQuery request, CancellationToken cancellationToken)
  {
    User user = await _context.Repository<User>().Where(row => row.Id == request.userId)
          .Include(row => row.Roles.Where(r => r.Role.ApplicationId == _identityManager.ApplicationId))
          .ThenInclude(ur => ur.Role)
          .Include(row => row.Applications.Where(a => a.ApplicationId == _identityManager.ApplicationId))
          .Include(row => row.Credentials)
          .FirstOrDefaultAsync();

    if (user is null)
      return Result.Failure<UserDetailDto>(type: ResultTypes.NotFound, [new Error("User.NotFound", "No se encontró el usuario")]);

    string? photoBase64 = null;
    if(user.PhotoNodeId is not null)
    {
      var alfrescoResult = await _alfresco.GetFileBytes(user.PhotoNodeId);
      photoBase64 = Convert.ToBase64String(alfrescoResult.Value);
    }

    return Result.Success(UserDetailDto.MapFrom(user, photoBase64));

  }
}
