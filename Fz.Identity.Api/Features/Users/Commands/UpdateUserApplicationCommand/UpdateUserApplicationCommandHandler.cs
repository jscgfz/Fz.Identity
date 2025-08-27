using Fz.Core.Cache.Abstractions;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Models.Identity;
using Fz.Identity.Api.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUserApplicationCommand;

public class UpdateUserApplicationCommandHandler(IServiceProvider provider) : ICommandHandler<UpdateUserApplicationCommand, Result>
{
  private readonly IDbContext _dbContext
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly ICacheManager _cacheManager
    = provider.GetRequiredService<ICacheManager>();
  private readonly IIdentityContextControlFieldsManager _identityManager
  = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result> Handle(UpdateUserApplicationCommand request, CancellationToken cancellationToken)
  {
    string updatetype = "Activación";
    User? user = await _dbContext.Repository<User>().FirstOrDefaultAsync(u => u.Id == request.UserId);
    if (user == null)
      return Result.Failure<RequestDetailDto>(type: ResultTypes.NotFound, [new Error("User.NotFound", "No se encontró el usuario solicitado")]);


    UserApplication? userApplication = await _dbContext.Repository<UserApplication>()
      .Where(row => row.UserId == request.UserId && row.ApplicationId == request.ApplicationId)
      .IncludeDeleted()
      .FirstOrDefaultAsync();

    if (userApplication is null)
    {
      userApplication = new()
      {
        UserId = request.UserId,
        ApplicationId = request.ApplicationId,
        IsDeleted = !request.IsActive
      };
      _dbContext.Add(userApplication);
    }
    else
    {
      userApplication.IsDeleted = !request.IsActive;
      _dbContext.Update(userApplication);

      if (!request.IsActive)
      {
        await _cacheManager.RemoveAsync($"session:{userApplication.ApplicationId}:{userApplication.UserId:N}");
        updatetype = "Desactivación";
      }
    }

    await _unitOfWork.SaveChangesAsync();

    AuditLog auditLog = new AuditLog
    {
      Action = Actions.EnableDisable,
      Module = "Gestión de usuarios",
      UserId = _identityManager.CurrentUserId,
      ApplicationId = (int)_identityManager.ApplicationId,
      Description = $"{updatetype} de usuario {user.Name} {user.Surname}",
      Entity = "user",
      EntityId = userApplication.UserId.ToString()
    };
    _dbContext.Add(auditLog);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success(ResultTypes.NoContent);
  }
}
