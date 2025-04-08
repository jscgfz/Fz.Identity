using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Request;

public record MpmUpdateAddressRequest(
  [property: JsonPropertyName("diR_Id")] int Id,
  [property: JsonPropertyName("diR_Direccion")] string Address,
  [property: JsonPropertyName("diR_Localidad")] string Locality,
  [property: JsonPropertyName("diR_TelfPal")] string PrincipalPhonNumber,
  [property: JsonPropertyName("diR_TelfSec")] string SecondaryPhonNumber,
  [property: JsonPropertyName("diR_TelfMovil")] string MobilePhonNumber,
  [property: JsonPropertyName("diR_Email")] string Email
);
