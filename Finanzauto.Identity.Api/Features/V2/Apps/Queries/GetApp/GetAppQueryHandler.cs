using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApp;

public sealed class GetAppQueryHandler(IServiceProvider provider) : IQueryHandler<GetAppQuery, AppDetailsDto>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public async Task<Result<AppDetailsDto>> Handle(GetAppQuery request, CancellationToken cancellationToken)
    => (await AppSpecifications
          .ByFilter(request)
          .Apply(_context.Repository<App>())
          .FirstAsync(cancellationToken))
.Success(
      );
}
