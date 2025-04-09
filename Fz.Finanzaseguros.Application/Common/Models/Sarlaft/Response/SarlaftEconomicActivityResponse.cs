namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftEconomicActivityResponse(
  Guid? MainActivityId,
  string? MainActivity,
  Guid? ActivityTypeId,
  string? ActivityType,
  string? Ciiu
);
