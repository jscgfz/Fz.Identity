using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record UserDetailDto(
    Guid Id,
  string Name,
  string Surname,
  string IdentificationNumber,
  string Email,
  bool? IsActive,
  string DocumentType,
  string UserName,
  string PhoneNumber,
  IEnumerable<RoleDto>? Roles
  )
{
  public static UserDetailDto MapFrom(User user)
  => new(
      user.Id,
      user.Name,
      user.Surname,
      user.IdentificationNumber,
      user.PrincipalEmail,
      user.Applications.Any() ? !user.Applications.FirstOrDefault().IsDeleted : null,
      user.DocumentType,
      user.Username,
      user.PrincipalPhoneNumber,
      (user.Roles.Any() ? user.Roles.Select(r => new RoleDto(r.RoleId, r.Role.Name, null)) : null)
    );
}
