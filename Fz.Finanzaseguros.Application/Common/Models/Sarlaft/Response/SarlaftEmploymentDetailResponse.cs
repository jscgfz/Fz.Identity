namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftEmploymentDetailResponse(
  Guid? Id,
  string? DepartmentId,
  string? DepartmentName,
  string? CityId,
  string? CityName,
  string? OtherOccupation,
  string? Position,
  string? Name,
  string? Address,
  string? PhoneNumber,
  Guid? CompanyTypeId,
  Guid? OccupationId,
  string? Occupation,
  SarlaftEconomicActivityResponse? EconomicActivity
);
