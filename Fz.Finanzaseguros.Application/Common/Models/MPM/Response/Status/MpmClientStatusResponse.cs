using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response.Status;
public sealed record MpmClientStatusResponse(
  [property: JsonPropertyName("cliente")] MpmClientResponse Client,
  bool IsSuccess,
  string Message
) : MpmStatusResponse(IsSuccess, Message);
