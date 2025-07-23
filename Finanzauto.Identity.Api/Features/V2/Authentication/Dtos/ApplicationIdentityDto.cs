namespace Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

public sealed record ApplicationIdentityDto(
  Guid Id,
  string Name,
  IEnumerable<RoleIdentityDto> Roles
);
