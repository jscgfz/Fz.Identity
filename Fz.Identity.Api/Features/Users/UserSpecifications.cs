using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.Users;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Users;

public sealed class UserSpecifications
{
  public static ISpecification<User, UserDto> ByUsersQuery(UsersQuery query)
    => new Specification<User, UserDto>()
      .WithFilter(row =>
        string.IsNullOrWhiteSpace(query.Filter) ||
        row.Id.ToString().Contains(query.Filter) ||
        row.Name.Contains(query.Filter) ||
        row.Surname.Contains(query.Filter) ||
        row.Username.Contains(query.Filter) ||
        (row.Name + " " + row.Surname).Trim().Contains(query.Filter) ||
        (!string.IsNullOrWhiteSpace(row.IdentificationNumber) && row.IdentificationNumber.Contains(query.Filter)) ||
        row.PrincipalEmail.Contains(query.Filter) ||
        row.Roles.Any(r => r.Role.Name.Contains(query.Filter))
      )
      .WithAndFilter(row => !query.ApplicationId.HasValue || row.Applications.Any(a => a.ApplicationId == query.ApplicationId))
      .WithAndFilter(row => !row.IsDeleted)
      .WithAndFilter(row => string.IsNullOrWhiteSpace(query.FullNameShort) || row.Surname.Contains(query.FullNameShort) || row.Name.Contains(query.FullNameShort))
      .WithAndFilter(row => string.IsNullOrWhiteSpace(query.Email) || row.PrincipalEmail.Contains(query.Email))
      .WithAndFilter(row => string.IsNullOrWhiteSpace(query.Role) || row.Roles.Where(r => r.Role.ApplicationId == query.ApplicationId).Any(r => r.Role.Name.Contains(query.Role)))
      .WithAndFilter(row => !query.IsActive.HasValue || !row.Applications.First(a => a.ApplicationId == query.ApplicationId).IsDeleted == query.IsActive)
      .WithAndFilter(row => (!query.DateFrom.HasValue || row.CreatedAtUtc.Date >= query.DateFrom.Value.Date) && (!query.DateTo.HasValue || row.CreatedAtUtc.Date <= query.DateTo.Value.Date))
      .WithAndFilter(row => !row.Credentials.Any(c => c.CredentialTypeId == (int)CredentialTypes.PassWord))
      .WithInclude(row => row.Roles.Where(r => !query.ApplicationId.HasValue || r.Role.ApplicationId == query.ApplicationId))
      .WithOrderBy(row => row.Name)
      .WithSelect(row => new(
        row.Id,
        row.Name,
        row.Surname,
        row.IdentificationNumber,
        row.PrincipalEmail,
        row.Applications.Any(a => a.ApplicationId == query.ApplicationId) ? !row.Applications.First(a => a.ApplicationId == query.ApplicationId).IsDeleted : null,
        row.Username,
        (row.Roles.Any() ? row.Roles.Where(r => r.Role.ApplicationId == query.ApplicationId).Select(r => new Roles.Dtos.RoleDto(r.RoleId, r.Role.Name, r.Role.ApplicationId)) : null),
        row.Credentials.Select(c => c.CredentialValue).Distinct(),
        row.PrincipalEmailConfirmed,
        row.PrincipalPhoneNumber,
        row.PrincipalPhoneNumberConfirmed,
        row.DocumentType,
        row.CreatedAtUtc.ToString("dd/MM/yyyy hh:mm tt")
      ))
    .WithDeleted();
}
