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
  private readonly ILDAPService _ldapAuth
    = provider.GetRequiredService<ILDAPService>();
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result<ValidateUserDto>> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
  {
    Application application = await _dbContext.Repository<Application>().FirstOrDefaultAsync(a => a.Id == _identityManager.ApplicationId);
    if (application is null)
      return Result.Failure<ValidateUserDto>(type: ResultTypes.NotFound, [new Error("Application.NotFound", "No se encontró la applicación")]);

    var userResult = await _ldapAuth.GetDetailUSer(request.UserName, application.Alias);
    if (userResult.IsFailure || userResult.Value.Message.Code != 0)
      return Result.Failure<ValidateUserDto>(ResultTypes.NotFound, [new Error("Role.NotFound", "Rol no asignado, comuniquese con tecnología")]);

    IEnumerable<string> rolesDa = userResult.Value.Roles.Select(r => r.Description);
    var roleId = Random.Shared.Next(4);
    var roles = await _dbContext.Repository<Role>().Where(r => r.ApplicationId == _identityManager.ApplicationId && rolesDa.Contains(r.ActiveDirectoryRole!.Name)).ToListAsync();
    if(roles.FirstOrDefault() is not Role role)
      return Result.Failure<ValidateUserDto>(ResultTypes.NotFound, [new Error("Role.NotFound", "Rol no asignado, comuniquese con tecnología")]);

    return Result.Success(new ValidateUserDto(role.Name, role.Id, role.Name.Contains("área", StringComparison.CurrentCultureIgnoreCase)));
  }
}
