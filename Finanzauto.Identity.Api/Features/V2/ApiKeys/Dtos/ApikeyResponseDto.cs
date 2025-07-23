namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;

public sealed record ApikeyResponseDto(
  Guid Id,
  string ApiKey
);
