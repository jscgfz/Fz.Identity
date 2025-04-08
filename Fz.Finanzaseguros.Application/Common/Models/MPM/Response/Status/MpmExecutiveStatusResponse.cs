using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response.Status;

public sealed record MpmExecutiveStatusResponse(
  [property: JsonPropertyName("ejecutivo")] MpmExecutiveResponse Executive,
  bool IsSuccess,
  string Message
) : MpmStatusResponse(IsSuccess, Message);
