using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmPolicyResponse(
  [property: JsonPropertyName("poL_Id")] int Id,
  [property: JsonPropertyName("poL_NumPoliza")] string Policynumber,
  [property: JsonPropertyName("raM_Alias")] string BouquetAlias,
  [property: JsonPropertyName("raM_Nombre")] string BouquetName,
  [property: JsonPropertyName("prO_Nombre")] string UnknownName,
  [property: JsonPropertyName("poL_PrimerEfecto")] DateTime PolicyFirstEffectDate,
  [property: JsonPropertyName("poL_FechaVencimiento")] DateTime PolicyExpiredDate,
  [property: JsonPropertyName("poL_Estado")] int PolicyStateId,
  [property: JsonPropertyName("poL_FormaPago")] int PolicyPaymentTypeId
);
