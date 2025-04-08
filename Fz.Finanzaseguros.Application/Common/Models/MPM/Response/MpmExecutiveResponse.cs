using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmExecutiveResponse(
  [property: JsonPropertyName("ejE_Id")] int Id,
  [property: JsonPropertyName("ejE_Nombre")] string Name,
  [property: JsonPropertyName("ejE_Email")] string Email,
  [property: JsonPropertyName("ejE_TelfMovil")] int PhonNumber,
  [property: JsonPropertyName("eje_Area")] string Area,
  [property: JsonPropertyName("ejE_Estado")] string StateId
);
