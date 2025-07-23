using Finanzauto.Core.Persistence.SqlServer;
using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Common;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;
using Finanzauto.Identity.Api.Models.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Users.Queries.GetUsers;

public sealed class GetUsersQueryHandler(IServiceProvider provider) : IQueryHandler<GetUsersQuery, IPaginatedResult<CreatedUserDto>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public Task<Result<IPaginatedResult<CreatedUserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    => SpecificationResolver.ComputeResult(
      UserSpecifications.ByFilter,
      request,
      _context,
      [new Error("Users.NotFound", "Usuarios no encontrados")]
    )
    .Map(result =>
    {
      return new PaginationSet<CreatedUserDto>(
        result.Data.Select(resume => resume with { Apps = resume.Apps.GroupBy(app => app.Id, (id, app) => new UserAppResumeDto(id, app.First().Name, app.First().Description, app.SelectMany(role => role.Roles))) }),
        result.PageCount,
        result.PageIndex,
        result.PageSize,
        result.Count
      );
    })
    .Map(result => (IPaginatedResult<CreatedUserDto>)result);
}
