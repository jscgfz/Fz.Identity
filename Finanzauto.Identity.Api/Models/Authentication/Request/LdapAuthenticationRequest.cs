using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Models.Authentication.Request;

public sealed record LdapAuthenticationRequest(
  [property: JsonPropertyName("usuario")] string UserName,
  [property: JsonPropertyName("clave")] string Password,
  [property: JsonPropertyName("dominio")] string? DomainName,
  [property: JsonPropertyName("firma")] string? Key
);
