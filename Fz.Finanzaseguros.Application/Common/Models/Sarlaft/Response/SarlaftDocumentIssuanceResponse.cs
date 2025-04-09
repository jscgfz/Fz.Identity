namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftDocumentIssuanceResponse(
  string? DepartmentId,
  string? DepartmentName,
  string? CityId,
  string? CityName,
  DateTime? IssueDate
);
