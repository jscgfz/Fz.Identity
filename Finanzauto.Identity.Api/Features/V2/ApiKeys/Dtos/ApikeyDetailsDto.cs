using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;

public sealed record ApikeyDetailsDto(
  Guid Id,
  string Comsumer,
  DateTime? CreatedAtUtc,
  AppDetailsDto App
);
