using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Models.Authentication.Response;

public sealed record LdapMessageResponse(
  [property: JsonPropertyName("codigoMensaje")] int Code,
  [property: JsonPropertyName("descMensaje")] string Description
);
