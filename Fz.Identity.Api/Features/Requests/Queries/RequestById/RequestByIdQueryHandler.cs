using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Extensions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Auth.Queries.Modules;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Roles.Queries.RoleById;
using Fz.Identity.Api.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Fz.Identity.Api.Features.Requests.Queries.RequestById;

public class RequestByIdQueryHandler(IServiceProvider provider) : IQueryHandler<RequestByIdQuery, Result<RequestDetailDto>>
{
  private readonly IDbContext _dbContext
     = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly ISender _sender
     = provider.GetRequiredService<ISender>();
  public async Task<Result<RequestDetailDto>> Handle(RequestByIdQuery request, CancellationToken cancellationToken)
  {
    var requestEntity = await _dbContext.Repository<Request>().Where(r => r.Id == request.Id)
      .Include(r => r.Status)
      .FirstOrDefaultAsync(cancellationToken);

    if (requestEntity is null)
      return Result.Failure<RequestDetailDto>(type: ResultTypes.NotFound, [new Error("Request.NotFound", "No se encontró la solicitud")]);

    var roleByIdResult = await _sender.Send(new RoleByIdQuery(requestEntity.ResourceId));
    if (roleByIdResult.IsFailure)
      return Result.ValidationError<RequestDetailDto>(roleByIdResult.Errors);

    var user = await _dbContext.Repository<User>().Where(u =>u.Id == requestEntity.CreatedBy)
      .IncludeDeleted()
      .FirstOrDefaultAsync(cancellationToken);

    if (user is null)
      return Result.Failure<RequestDetailDto>(type: ResultTypes.NotFound, [new Error("User.NotFound", "No se encontró el usuario")]);

    var managementUser = await _dbContext.Repository<User>().Where(u => u.Id == requestEntity.ProcessedBy)
      .IncludeDeleted()
      .FirstOrDefaultAsync(cancellationToken);

    return Result.Success(RequestDetailDto.MapFrom(requestEntity, roleByIdResult.Value, user, managementUser));
  }
}
