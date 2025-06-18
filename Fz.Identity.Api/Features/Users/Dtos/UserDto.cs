using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Users.Dtos;

public sealed record UserDto(
  Guid Id,
  string Name,
  string Surname,
  string? IdentificationNumber,
  string Email,
  bool? IsActive,
  string UserName,
  IEnumerable<RoleDto>? Roles,
  IEnumerable<string>? UserNames,
  bool PrincipalEmailConfirmed,
  string? PrincipalPhoneNumber,
  bool PrincipalPhoneNumberConfirmed,
  string? DocumentType
  DateTime? CreatedDate,
  IEnumerable<RoleDto>? Roles
)
{
  public static UserDto MapFrom(User user)
    => new(
        user.Id,
        user.Name,
        user.Surname,
        user.IdentificationNumber,
        user.PrincipalEmail,
        user.IsDeleted,
        user.Username,
        (user.Roles.Any() ? user.Roles.Select(r => new RoleDto(r.RoleId, r.Role.Name, null)) : null),
        user.Credentials.Select(c => c.CredentialValue).Distinct(),
        user.PrincipalEmailConfirmed,
        user.PrincipalPhoneNumber,
        user.PrincipalPhoneNumberConfirmed,
        user.DocumentType
        TimeZoneInfo.ConvertTime(user.CreatedAtUtc, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")),
        (user.Roles.Any() ? user.Roles.Select(r => new RoleDto(r.RoleId, r.Role.Name, null)) : null)
      );
}
