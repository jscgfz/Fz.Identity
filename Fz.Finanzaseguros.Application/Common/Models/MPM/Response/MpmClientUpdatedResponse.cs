using Fz.Finanzaseguros.Application.Common.Models.MPM.Request;
using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmClientUpdatedResponse(
  [property: JsonPropertyName("estado")] string State,
  int Id,
  string Name,
  string LastName1,
  string LastName2,
  int GenderId,
  DateTime BirthDate,
  int ComunicationViaId
) : MpmUpdateClientRequest(Id, Name, LastName1, LastName2, GenderId, BirthDate, ComunicationViaId);
