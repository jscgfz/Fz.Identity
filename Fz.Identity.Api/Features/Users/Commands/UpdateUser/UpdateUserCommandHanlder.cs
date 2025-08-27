using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Users.Commands.AddUser;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Channels;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHanlder(IServiceProvider provider) : ICommandHandler<UpdateUserCommand, Result>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  private readonly IAlfrescoService _alfresco
    = provider.GetRequiredService<IAlfrescoService>();
  public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    User? user = await _dbContext.Repository<User>()
    .FirstOrDefaultAsync(row => row.Id == request.id, cancellationToken);
    if (user is null)
      return Result.Failure(type: ResultTypes.NotFound, [new Error("User.NotFound", "No se encontró el usuario")]);

    string changes = string.Empty;
    try
    {
      if (request.PhotoBase64 is not null)
      {
        var alfresoResult = await _alfresco.UploadFile(request.UserName, request.PhotoBase64);
        if (alfresoResult.IsFailure)
          return Result.ValidationError<UserAddedResponseDto>(alfresoResult.Errors);
        user.PhotoNodeId = alfresoResult.Value;
      }
      else
        user.PhotoNodeId = null;

      changes = GetDiffrences(user, request);

      user.Name = request.Name;
      user.Surname = request.Surname;
      user.PrincipalEmail = request.Email;
      user.IdentificationNumber = request.IdentificationNumber;
      user.PrincipalPhoneNumber = request.PhoneNamuber;
      user.DocumentType = request.DocumentType;
      user.Username = request.UserName;
      user.AreaId = request.AreaId;

      _dbContext.Update(user);
      await _unitOfWork.SaveChangesAsync(cancellationToken);

      IEnumerable<UserApplication> userApplications = _dbContext.Repository<UserApplication>()
        .Where(row => row.UserId == request.id && row.ApplicationId == _identityManager.ApplicationId)
        .IncludeDeleted();
      if (userApplications.Any())
      {
        UserApplication userApplication = userApplications.FirstOrDefault();
        userApplication.IsDeleted = !(request.IsActive ?? !userApplication.IsDeleted);
        _dbContext.Update(userApplication);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
      }

      if (request.RoleIds is null)
        return Result.Success(ResultTypes.NoContent);

      IEnumerable<UserRole> userRoles = _dbContext.Repository<UserRole>()
        .Where(row => row.UserId == request.id && row.Role.ApplicationId == _identityManager.ApplicationId)
        .Include(ur => ur.Role)
        .IncludeDeleted();
      string? currentRole = userRoles.FirstOrDefault(ur => !ur.IsDeleted)?.Role.Name;

      IEnumerable<UserRole> userRolesToDelete = userRoles.Where(ur => !request.RoleIds.Contains(ur.RoleId) && !ur.IsDeleted);
      if (userRolesToDelete.Any())
        _dbContext.DeleteRange(userRolesToDelete);

      List<UserRole> userRolesToUpdate = userRoles.Where(ur => request.RoleIds.Contains(ur.RoleId) && ur.IsDeleted).ToList();

      if (userRolesToUpdate.Any())
      {
        userRolesToUpdate.ForEach(ur => ur.IsDeleted = false);
        _dbContext.UpdateRange(userRolesToUpdate);
        var newRole = userRolesToUpdate.FirstOrDefault();
        var roleDifference = await GetRoleDifference(currentRole, newRole.RoleId);
        changes += string.IsNullOrEmpty(changes) ? roleDifference : $", {roleDifference}";
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
        var newRoleId = newUserRoleIds.FirstOrDefault();
        var roleDifference = await GetRoleDifference(currentRole, newRoleId);
        changes += string.IsNullOrEmpty(changes) ? roleDifference : $", {roleDifference}";
      }
      await _unitOfWork.SaveChangesAsync(cancellationToken);
      return Result.Success(ResultTypes.NoContent);
    }
    finally
    {
      AuditLog auditLog = new AuditLog
      {
        Action = Actions.Edit,
        Module = "Gestión de usuarios",
        UserId = _identityManager.CurrentUserId,
        ApplicationId = (int)_identityManager.ApplicationId,
        Description = $"Edición de usuario {GetShrotName(request.Name, request.Surname)}: {changes}",
        Entity = "user",
        EntityId = user.Id.ToString()
      };
      _dbContext.Add(auditLog);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
  }

  private string GetDiffrences(User user, UpdateUserCommand request)
  {
    var equivalences = new Dictionary<string, string>
    {
      { "PrincipalEmail", "Email" },
      { "PrincipalPhoneNumber", "PhoneNamuber" }
    };

    var userProperties = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    var updateUserProperties = typeof(UpdateUserCommand).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    var changes = new List<string>();
    foreach (var property in userProperties)
    {
      string updatePropName = property.Name;
      if (equivalences.TryGetValue(property.Name, out var mmapedName))
        updatePropName = mmapedName;

      var updateProp = updateUserProperties.FirstOrDefault(p => p.Name == updatePropName);
      if (updateProp == null) continue;

      var oldValue = property.GetValue(user);
      var newValue = updateProp.GetValue(request);
      if (!Equals(oldValue, newValue))
      {
        var displayName = property.GetCustomAttribute<DisplayAttribute>()?.Name ?? property.Name;
        changes.Add($"{displayName}: {oldValue} a {newValue}");
      }
    }
    return string.Join(", ", changes);
  }

  private async Task<string> GetRoleDifference(string oldrole, Guid newRoleId)
  {
    var newRole = await _dbContext.Repository<Role>().FirstOrDefaultAsync(r => r.Id == newRoleId);
    return $"Rol: {oldrole} a {newRole.Name}";
  }

  private string GetShrotName(string name, string surname)
  {
    var firstName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
    var firstSurname = surname.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

    return $"{firstName} {firstSurname}";
  }
}
