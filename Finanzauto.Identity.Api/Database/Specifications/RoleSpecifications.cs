using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Features.V2.Roles.Dtos;
using Finanzauto.Identity.Api.Features.V2.Roles.Queries.GetRoles;

namespace Finanzauto.Identity.Api.Database.Specifications;

public static class RoleSpecifications
{
  public static ISpecification<Role, RoleDto> ByFilter(GetRolesQuery query)
  => new SpecificationBuilder<Role, RoleDto>()
      .WithInclude(row => row.App)
      .WithFilter(row => string.IsNullOrWhiteSpace(query.Filter))
      .WithOrFilter(row => row.Name.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrWhiteSpace(row.Description) && row.Description.Contains(query.Filter!))
      .WithOrFilter(row => row.Id.ToString().Contains(query.Filter!))
      .WithOrFilter(row => row.App.Id.ToString().Contains(query.Filter!))
      .WithOrFilter(row => row.App.AppIndex.ToString().Contains(query.Filter!))
      .WithSelect(row => new RoleDto(
        row.Id,
        row.App.Id,
        row.App.AppIndex,
        row.Name,
        row.Description
      ));
}
