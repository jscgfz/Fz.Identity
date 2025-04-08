using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response.Status;
public sealed record MpmCompanyStatusResponse(
  [property: JsonPropertyName("compania")] MpmCompanyResponse Company,
  bool IsSuccess,
  string Message
) : MpmStatusResponse(IsSuccess, Message);
