using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Common;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Features.V2.Roles.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Roles.Queries.GetRoles;

public sealed class GetRolesQueryHandler(IServiceProvider provider) : IQueryHandler<GetRolesQuery, IPaginatedResult<RoleDto>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public Task<Result<IPaginatedResult<RoleDto>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    => SpecificationResolver.ComputeResult(
      RoleSpecifications.ByFilter,
      request,
      _context,
      [new Error("Roles.NotFound", "Roles no encontrados")]
    );
}
