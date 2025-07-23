namespace Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

public sealed record FullClaimDto(
  string Value,
  ClaimResponseDto Action,
  ClaimResponseDto Section
);
