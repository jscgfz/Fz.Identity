using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Models.Authentication.Response;

public sealed record LdapAuthenticationResponse(
  [property: JsonPropertyName("mensaje")] LdapMessageResponse Message,
  IEnumerable<LdapRoleResponse> Roles
);
