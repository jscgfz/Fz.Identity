using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHanlder(IServiceProvider provider) : ICommandHandler<UpdateUserCommand, Result>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    User user = await _dbContext.Repository<User>().FirstOrDefaultAsync(row => row.Id == request.id, cancellationToken);
    if (user is null)
      return Result.Failure(type: ResultTypes.NotFound, [new Error("User.NotFound", "No se encontró el usuario")]);

    user.Name = request.Name;
    user.Surname = request.Surname;
    user.PrincipalEmail = request.Email;
    user.IdentificationNumber = request.IdentificationNumber;
    user.PrincipalPhoneNumber = request.PhoneNamuber;
    user.DocumentType = request.DocumentType;
    user.Username = request.UserName;

    _dbContext.Update(user);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    IEnumerable<UserRole> userRoles = _dbContext.Repository<UserRole>()
      .Where(row => row.UserId == request.id && row.Role.ApplicationId == _identityManager.ApplicationId)
      .IncludeDeleted();

    IEnumerable<UserRole> userRolesToDelete = userRoles.Where(ur => !request.RoleIds.Contains(ur.RoleId) && !ur.IsDeleted);
    if (userRolesToDelete.Any())
      _dbContext.DeleteRange(userRolesToDelete);

    List<UserRole> userRolesToUpdate = userRoles.Where(ur => request.RoleIds.Contains(ur.RoleId) && ur.IsDeleted).ToList();

    if (userRolesToDelete.Any())
    {
      userRolesToUpdate.ForEach(ur => ur.IsDeleted = false);
      _dbContext.UpdateRange(userRolesToUpdate);
    }

    IEnumerable<Guid> newUserRoleIds = request.RoleIds.Except(userRoles.Select(ur => ur.RoleId));
    if (newUserRoleIds.Any())
    {
      List<UserRole> newUserRoles = new();
      foreach (var roleId in newUserRoleIds)
      {
        UserRole userRole = new()
        {
          RoleId = roleId,
          UserId = user.Id,
        };
        newUserRoles.Add(userRole);
      }
      _dbContext.AddRange(newUserRoles);
    }
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success(ResultTypes.NoContent);
  }
}
