namespace Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

public sealed record ClaimRequestDto(
  string Value,
  string? Description
);
