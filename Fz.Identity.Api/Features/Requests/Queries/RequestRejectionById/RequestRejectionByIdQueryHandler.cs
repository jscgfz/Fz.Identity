using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Requests.Queries.RequestRejectionById;

public class RequestRejectionByIdQueryHandler(IServiceProvider provider) : IQueryHandler<RequestRejectionByIdQuery, Result<RequestRejectionDto>>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  public async Task<Result<RequestRejectionDto>> Handle(RequestRejectionByIdQuery request, CancellationToken cancellationToken)
  {
    var requestEntity = await _dbContext.Repository<Request>().Where(r => r.Id == request.RequestId && r.StatusId == (int)RequestStatuses.Rejected)
      .FirstOrDefaultAsync(cancellationToken);

    if (requestEntity is null)
      return Result.Failure<RequestRejectionDto>(type: ResultTypes.NotFound, [new Error("Request.NotFound", "No se encontró la solicitud")]);

    var rejecttionUser = await _dbContext.Repository<User>().Where(u => u.Id == requestEntity.ProcessedBy)
      .IncludeDeleted()
      .FirstOrDefaultAsync();

    return Result.Success(RequestRejectionDto.MapFrom(requestEntity, rejecttionUser));
  }
}
