using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Requests.Queries.Requests;

public sealed class RequestsQueryHandler(IServiceProvider provider) : IQueryHandler<RequestsQuery, Result<IPaginatedResult<RequestDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  public async Task<Result<IPaginatedResult<RequestDto>>> Handle(RequestsQuery request, CancellationToken cancellationToken)
  {
    var result = SpecificationResolver.ComputeResult(
    RequestSpecification.ByRequestsQuery,
    request,
    _context,
    [new Error("Requests.NotFound", "no se encontraron solicitudes para la consulta")]
    );

    List<Guid> userids = result.Result.Value.Data.Select(x => x.UserId)
      .Distinct()
      .ToList();

    var users = await _context.Repository<User>()
      .Where(u => userids.Contains(u.Id))
      .ToDictionaryAsync(u => u.Id, u => $"{u.Name} {u.Surname}");

    foreach (var requestEntity in result.Result.Value.Data)
    {
      if (users.TryGetValue(requestEntity.UserId, out var userName))
        requestEntity.User = userName;
    }

    return await result;
  }
}
