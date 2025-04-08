using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmUserResponse(
  [property: JsonPropertyName("usR_Id")] int Id,
  [property: JsonPropertyName("usR_Nombre")] string Name,
  [property: JsonPropertyName("usR_Email")] string Email,
  [property: JsonPropertyName("usR_Extension")] int Extension,
  [property: JsonPropertyName("usR_Departamento")] string Departament,
  [property: JsonPropertyName("usR_Departamento")] int UserStateId
);
