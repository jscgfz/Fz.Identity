using Finanzauto.Identity.Api.Models.Roles.Dto;

namespace Finanzauto.Identity.Api.Models.Apps.Dtos;

public sealed record UserAppResumeDto(
  Guid Id,
  string Name,
  string? Description,
  IEnumerable<RoleResumeDto> Roles
);
