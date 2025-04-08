using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmClientResponse(
  [property: JsonPropertyName("clI_Id")] int Id,
  [property: JsonPropertyName("clI_Nombre")] string Name,
  [property: JsonPropertyName("clI_Apellido1")] string LastName1,
  [property: JsonPropertyName("clI_Apellido2")] string LastName2,
  [property: JsonPropertyName("clI_NIF")] string Dni,
  [property: JsonPropertyName("clI_Sexo")] int GenderId,
  [property: JsonPropertyName("clI_Genero")] string GenderName,
  [property: JsonPropertyName("clI_Nacimiento")] DateTime BirthDay,
  [property: JsonPropertyName("cli_Edad")] int Age,
  [property: JsonPropertyName("dir_id")] int AddressId,
  [property: JsonPropertyName("diR_Direccion")] string Address,
  [property: JsonPropertyName("diR_Localidad")] string City,
  [property: JsonPropertyName("diR_TelfPal")] string PrincipalPhoneNumber,
  [property: JsonPropertyName("diR_TelfSec")] string SecondaryPhoneNumber,
  [property: JsonPropertyName("diR_TelfMovil")] string MobilePhoneNumber,
  [property: JsonPropertyName("diR_Email")] string Email,
  [property: JsonPropertyName("vcO_ID")] int ComunicationViaId,
  [property: JsonPropertyName("vcO_LiteralOpcion")] string ComunicationViaName
);
