using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Requests.Commands.ApproveRerquest;

public class ApproveRequestCommandHandler(IServiceProvider provider) : ICommandHandler<ApproveRequestCommand, Result>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  public async Task<Result> Handle(ApproveRequestCommand request, CancellationToken cancellationToken)
  {
    var requestEntity = await _dbContext.Repository<Request>().Where(r => r.Id == request.RequestId && r.StatusId == (int)RequestStatuses.Pending).FirstOrDefaultAsync(cancellationToken);

    if (requestEntity is null)
      return Result.Failure(type: ResultTypes.NotFound, [new Error("Request.NotFound", "No se encontró la solicitud")]);

    requestEntity.StatusId = (int)RequestStatuses.Approved;
    requestEntity.ProcessedAt = DateTime.UtcNow;
    requestEntity.ProcessedBy = _identityManager.CurrentUserId;
    requestEntity.RequiresConfirmation = true;
    _dbContext.Update(requestEntity);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success();
  }
}
