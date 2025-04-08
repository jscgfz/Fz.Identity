using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmColaboratorResponse(
  [property: JsonPropertyName("coL_Id")] int Id,
  [property: JsonPropertyName("coL_Nombre")] string Name,
  [property: JsonPropertyName("coL_Email")] string Email,
  [property: JsonPropertyName("coL_TelfMovil")] string MobilePhoneNumber,
  [property: JsonPropertyName("col_Area")] string Area,
  [property: JsonPropertyName("coL_Estado")] int StateId
);
