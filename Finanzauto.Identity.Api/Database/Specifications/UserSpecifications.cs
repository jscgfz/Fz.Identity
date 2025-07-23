using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;
using Finanzauto.Identity.Api.Features.V2.Users.Queries.GetUsers;
using Finanzauto.Identity.Api.Models.Apps.Dtos;
using Finanzauto.Identity.Api.Models.Roles.Dto;

namespace Finanzauto.Identity.Api.Database.Specifications;

public static class UserSpecifications
{
  public static ISpecification<User, CreatedUserDto> ByFilter(GetUsersQuery query)
    => new SpecificationBuilder<User, CreatedUserDto>()
      .WithInclude(
        $"{nameof(User.AsignedRoles)}.{nameof(UserRole.Role)}.{nameof(Role.App)}"
      )
      .WithFilter(row => string.IsNullOrEmpty(query.Filter))
      .WithOrFilter(row => !string.IsNullOrEmpty(row.DocumentTypeId) && row.DocumentTypeId.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrEmpty(row.DocumentNumber) && row.DocumentNumber.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrEmpty(row.SecondName) && row.SecondName.Contains(query.Filter!))
      .WithOrFilter(row => row.FirstName.Contains(query.Filter!))
      .WithOrFilter(row => row.FirstLastName.Contains(query.Filter!))
      .WithOrFilter(row => row.SecondLastName.Contains(query.Filter!))
      .WithOrFilter(row => row.SecondLastName.Contains(query.Filter!))
      .WithOrFilter(row => row.ContactInfo.Email.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrEmpty(row.ContactInfo.PhoneNumber) && row.ContactInfo.PhoneNumber.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrEmpty(row.ContactInfo.Address) && row.ContactInfo.Address.Contains(query.Filter!))
      .WithOrFilter(row => row.AsignedRoles.Any(role => role.Role.Name.Contains(query.Filter!)))
      .WithOrFilter(row => row.AsignedRoles.Any(role => !string.IsNullOrEmpty(role.Role.Description) && role.Role.Description.Contains(query.Filter!)))
      .WithOrFilter(row => row.AsignedRoles.Any(role => role.Role.App.ApplicationName.Contains(query.Filter!)))
      .WithOrFilter(row => row.AsignedRoles.Any(role => !string.IsNullOrEmpty(role.Role.App.Description) && role.Role.App.Description.Contains(query.Filter!)))
      .WithOrFilter(row => row.Credentials.Any(credential => credential.UserName.Contains(query.Filter!)))
      .WithOrFilter(row => row.SingleCredentials.Any(credential => credential.UserName.Contains(query.Filter!)))
      .WithOrderByDesc(row => row.CreatedAtUtc!.Value)
      .WithSelect(row => new CreatedUserDto(
        row.Id,
        row.DocumentTypeId,
        row.DocumentNumber,
        row.FirstName,
        row.SecondName,
        row.FirstLastName,
        row.SecondLastName,
        row.ContactInfo.Email,
        row.ContactInfo.PhoneNumber,
        row.ContactInfo.Address,
        row.AsignedRoles.Select(role => new UserAppResumeDto(
          role.Role.App.Id,
          role.Role.App.ApplicationName,
          role.Role.App.Description,
          new[] { new RoleResumeDto(role.Role.Id, role.Role.Name, role.Role.Description) }
        ))
      ));
}
