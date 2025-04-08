using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmCompanyResponse(
  [property: JsonPropertyName("ciA_Id")] int Id,
  [property: JsonPropertyName("ciA_Nombre")] string Name,
  [property: JsonPropertyName("ciA_Numemergencia")] string EmergencyPhoneNumber,
  [property: JsonPropertyName("ciA_Url")] string Url,
  [property: JsonPropertyName("ciA_Estado")] int StateId
);
