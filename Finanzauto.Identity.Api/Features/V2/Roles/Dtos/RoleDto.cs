namespace Finanzauto.Identity.Api.Features.V2.Roles.Dtos;


public sealed record RoleDto(
  Guid Id,
  Guid AppUid,
  int AppId,
  string Name,
  string? Description
);
