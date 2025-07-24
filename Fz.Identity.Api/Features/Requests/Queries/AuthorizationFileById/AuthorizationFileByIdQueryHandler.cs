using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Requests.Queries.AuthorizationFileById;

public class AuthorizationFileByIdQueryHandler(IServiceProvider provider) : IQueryHandler<AuthorizationFileByIdQuery, Result<FileDto>>
{
  private readonly IReadOnlyDbContext _dbContext
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IAlfrescoService _alfresco
    = provider.GetRequiredService<IAlfrescoService>();
  public async Task<Result<FileDto>> Handle(AuthorizationFileByIdQuery request, CancellationToken cancellationToken)
  {
    var requestEntity = await _dbContext.Repository<Request>().Where(r => r.Id == request.RequestId).FirstOrDefaultAsync(cancellationToken);
    if (requestEntity is null)
      return Result.Failure<FileDto>(type: ResultTypes.NotFound, [new Error("Request.NotFound", "No se encontró la solicitud")]);

    var alfrescoResult = await _alfresco.GetFileBytes(requestEntity.AuthorizationFileId);
    if (alfrescoResult.IsFailure)
      return Result.Failure<FileDto>(ResultTypes.InternalServerError, alfrescoResult.Errors);

    return Result.Success(new FileDto(
      requestEntity.AuthorizationFileName,
      alfrescoResult.Value,
      "application.pdf"
      ));
  }
}
