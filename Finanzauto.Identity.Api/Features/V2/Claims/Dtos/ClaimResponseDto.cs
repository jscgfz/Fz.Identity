namespace Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

public sealed record ClaimResponseDto(
  int Id,
  string Value,
  string? Description
);
