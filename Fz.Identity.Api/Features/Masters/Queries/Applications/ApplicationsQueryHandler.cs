using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Masters.Queries.Applications;

public sealed class ApplicationsQueryHandler(IServiceProvider provider) : IQueryHandler<ApplicationsQuery, Result<IEnumerable<ApplicationDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

  public async Task<Result<IEnumerable<ApplicationDto>>> Handle(ApplicationsQuery request, CancellationToken cancellationToken)
  {
    var query = _context.Repository<Application>();
    if (request.OnlyGroup)
    {
      Application application = await _context.Repository<Application>().FirstOrDefaultAsync(row => row.Id == _identityManager.ApplicationId);
      query = query.Where(a => a.CompanyId == application.CompanyId);
    }

    return Result.From(
      await query.Select(row => new ApplicationDto(row.Id, row.Name)).ToListAsync(cancellationToken),
      ResultTypes.NotFound,
      [new Error("Applications.NotFound")]
    )
    .Map(result => result.AsEnumerable());
  }
}
