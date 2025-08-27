using Azure;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Requests.Commands.AddRequest;

public class AddRequestCommandHandler(IServiceProvider provider) : ICommandHandler<AddRequestCommand, Result>
{
  private readonly IDbContext _dbContext
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);
  private readonly IAlfrescoService _alfresco
    = provider.GetRequiredService<IAlfrescoService>();
  public async Task<Result> Handle(AddRequestCommand request, CancellationToken cancellationToken)
  {
    Request? pendingRequest = await _dbContext.Repository<Request>().Where(r => r.RoleId == request.RoleId && r.StatusId == (int)RequestStatuses.Pending).FirstOrDefaultAsync();
    if (pendingRequest != null)
      return Result.Failure(ResultTypes.BadRequest, [new Error("Request.Create", "Creación fallida - ya existe un solicitud pendiente")]);

    Role? role = await _dbContext.Repository<Role>().FirstOrDefaultAsync(r => r.Id == request.RoleId);
    if(role is null)
      return Result.Failure<RequestDetailDto>(type: ResultTypes.NotFound, [new Error("Role.NotFound", "No se encontró el rol solicitado")]);

    Request requestEntity = new()
    {
      RoleId = request.RoleId,
      Reason = request.Reason,
      ApplicationId = (int)_identityManager.ApplicationId,
      ChangesJson = request.ChangesJson,
      StatusId = (int)RequestStatuses.Pending,
      AuthorizationFileName = request.AuthorizationFile.FileName,
    };

    _dbContext.Add(requestEntity);

    string? authorizationFileId = null;

    var alfresoResult = await _alfresco.UploadAuthFile(request.RoleId, requestEntity.Id, request.AuthorizationFile);
    if (alfresoResult.IsFailure)
      return Result.ValidationError<UserAddedResponseDto>(alfresoResult.Errors);
    authorizationFileId = alfresoResult.Value;

    requestEntity.AuthorizationFileId = authorizationFileId;
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    AuditLog auditLog = new AuditLog { 
      Action = Actions.Create,
      Module = "Gestión de roles",
      UserId = _identityManager.CurrentUserId,
      ApplicationId = (int)_identityManager.ApplicationId,
      Description = $"Creación de solicitud edición rol {role.Name} ",
      Entity = "request",
      EntityId = requestEntity.Id.ToString()
    };
    _dbContext.Add(auditLog);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success(requestEntity);
  }
}
