using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Request;

public sealed record MpmAuthRequest(
  [property: JsonPropertyName("usr_Login")] string Username,
  [property: JsonPropertyName("Usr_PassIng")] string Password
);
