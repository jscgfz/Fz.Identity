using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Request;

public record MpmUpdateClientRequest(
  [property: JsonPropertyName("clI_Id")] int Id,
  [property: JsonPropertyName("clI_Nombre")] string Name,
  [property: JsonPropertyName("clI_Apellido1")] string LastName1,
  [property: JsonPropertyName("clI_Apellido2")] string LastName2,
  [property: JsonPropertyName("clI_Sexo")] int GenderId,
  [property: JsonPropertyName("clI_Nacimiento")] DateTime BirthDate,
  [property: JsonPropertyName("vcO_ID")] int ComunicationViaId
);
