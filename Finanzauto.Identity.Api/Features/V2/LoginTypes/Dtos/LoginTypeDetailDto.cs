using Finanzauto.Identity.Api.Domain.Enums.Authentication;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;

public sealed record LoginTypeDetailDto(
  int Id,
  string Name,
  string? Description,
  string? DomainGroup,
  string? DomainKey,
  AuthenticationTypes AuthenticationType
);
