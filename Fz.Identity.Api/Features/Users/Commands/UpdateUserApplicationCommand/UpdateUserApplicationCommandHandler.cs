using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUserApplicationCommand;

public class UpdateUserApplicationCommandHandler(IServiceProvider provider) : ICommandHandler<UpdateUserApplicationCommand, Result>
{
  private readonly IDbContext _dbContext
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  public async Task<Result> Handle(UpdateUserApplicationCommand request, CancellationToken cancellationToken)
  {
    UserApplication? userApplication = await _dbContext.Repository<UserApplication>()
      .Where(row => row.UserId == request.UserId && row.ApplicationId == request.ApplicationId)
      .IncludeDeleted()
      .FirstOrDefaultAsync();

    if(userApplication is null)
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
    }

    await _unitOfWork.SaveChangesAsync();

    return Result.Success(ResultTypes.NoContent);
  }
}
