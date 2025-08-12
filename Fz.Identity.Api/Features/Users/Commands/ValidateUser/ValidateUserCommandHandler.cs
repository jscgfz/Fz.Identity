using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Users.Commands.ValidateUser;

public class ValidateUserCommandHandler(IServiceProvider provider) : ICommandHandler<ValidateUserCommand, Result<ValidateUserDto>>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly ILDAPAuthService _ldapAuth
    = provider.GetRequiredService<ILDAPAuthService>();
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result<ValidateUserDto>> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
  {
    Application application = await _dbContext.Repository<Application>().FirstOrDefaultAsync(a => a.Id == _identityManager.ApplicationId);
    if (application is null)
      return Result.Failure<ValidateUserDto>(type: ResultTypes.NotFound, [new Error("Application.NotFound", "No se encontró la applicación")]);

    var userResult = await _ldapAuth.GetDetailUSer(request.UserName, application.Alias);
    bool hasArea = false;
    if (userResult.IsFailure || userResult.Value.Message.Code != 0)
      hasArea = Random.Shared.Next(2) == 1;

    var roleId = Random.Shared.Next(4);
    var roles = await _dbContext.Repository<Role>().Where(r => r.ApplicationId == _identityManager.ApplicationId && !r.ActiveDirectoryRole.Name.Contains("area")).ToListAsync();
    var role = roles[roleId];

    if(hasArea)
      role = await _dbContext.Repository<Role>().FirstOrDefaultAsync(r => r.ActiveDirectoryRole.Name.Contains("area") && r.ApplicationId == _identityManager.ApplicationId);

    return Result.Success(new ValidateUserDto(role.Name, role.Id, hasArea));
  }
}
