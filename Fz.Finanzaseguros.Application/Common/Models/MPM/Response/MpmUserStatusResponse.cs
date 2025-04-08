using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmUserStatusResponse(
  [property: JsonPropertyName("usuario")] MpmUserResponse User,
  bool IsSuccess,
  string Message
) : MpmStatusResponse(IsSuccess, Message);
