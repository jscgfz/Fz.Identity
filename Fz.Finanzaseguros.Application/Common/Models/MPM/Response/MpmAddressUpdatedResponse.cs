using Fz.Finanzaseguros.Application.Common.Models.MPM.Request;
using System.Text.Json.Serialization;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Response;

public sealed record MpmAddressUpdatedResponse(
  [property: JsonPropertyName("estado")] string State,
  int Id,
  string Address,
  string Locality,
  string PrincipalPhonNumber,
  string SecondaryPhonNumber,
  string MobilePhonNumber,
  string Email
) : MpmUpdateAddressRequest(Id, Address, Locality, PrincipalPhonNumber, SecondaryPhonNumber, MobilePhonNumber, Email);
