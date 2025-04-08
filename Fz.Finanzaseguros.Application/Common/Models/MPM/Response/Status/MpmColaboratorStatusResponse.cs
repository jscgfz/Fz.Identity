using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response.Status;
public sealed record MpmColaboratorStatusResponse(
  [property: JsonPropertyName("colaborador")] MpmColaboratorResponse Colaborator,
  bool IsSuccess,
  string Message
) : MpmStatusResponse(IsSuccess, Message);
