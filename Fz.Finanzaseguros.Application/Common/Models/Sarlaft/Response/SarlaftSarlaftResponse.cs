namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftSarlaftResponse(
  Guid Id,
  string Name,
  string? DepartmentId,
  string? DepartmentName,
  string? CityId,
  string? CityName,
  Guid UserId,
  string? UserName,
  DateTime RegisteredDate,
  int? RequestTypeId,
  string? RequestType,
  string? LinkClass,
  Guid? LinkClassId,
  Guid? ProductTypeId,
  string? ElectronicSignStatus,
  string? SarlaftStatus,
  bool? IsClauseAccepted,
  SarlaftClientResponse? Client,
  string? SarlaftVersion
);
