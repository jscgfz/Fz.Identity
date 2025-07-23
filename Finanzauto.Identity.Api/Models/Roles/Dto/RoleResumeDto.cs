namespace Finanzauto.Identity.Api.Models.Roles.Dto;

public sealed record RoleResumeDto(
  Guid Id,
  string Name,
  string? Description
);
