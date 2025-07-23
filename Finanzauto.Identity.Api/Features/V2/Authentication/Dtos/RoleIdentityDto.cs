namespace Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

public sealed record RoleIdentityDto(
  Guid Id,
  string Name,
  string? DomainName
);
