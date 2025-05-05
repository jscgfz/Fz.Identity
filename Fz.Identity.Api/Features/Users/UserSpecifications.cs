using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.Users;

namespace Fz.Identity.Api.Features.Users;

public sealed class UserSpecifications
{
  public static ISpecification<User, UserDto> ByUsersQuery(UsersQuery query)
    => new Specification<User, UserDto>()
      .WithFilter(row =>
        string.IsNullOrWhiteSpace(query.Filter) ||
        row.Name.Contains(query.Filter) ||
        row.Surname.Contains(query.Filter) ||
        row.Username.Contains(query.Filter) ||
        (row.Name + " " + row.Surname).Trim().Contains(query.Filter) ||
        row.IdentificationNumber.Contains(query.Filter) ||
        row.PrincipalEmail.Contains(query.Filter)
      )
      .WithAndFilter(row => !query.ApplicationId.HasValue || row.Applications.Any(a => a.ApplicationId == query.ApplicationId))
      .WithInclude(row => row.Roles.Where(r => !query.ApplicationId.HasValue || r.Role.ApplicationId == query.ApplicationId))
      .WithOrderBy(row => row.Name)
      .WithSelect(row => new(
        row.Id,
        row.Name,
        row.Surname,
        row.IdentificationNumber,
        row.PrincipalEmail,
        row.Roles.Any() ? row.Roles.Select(r => new Roles.Dtos.RoleDto(r.RoleId, r.Role.Name, r.Role.ApplicationId)) : null,
        row.IsDeleted
      ));
}
