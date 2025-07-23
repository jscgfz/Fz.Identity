using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Models.Authentication.Response;

public sealed record LdapRoleResponse(
  [property: JsonPropertyName("descripcion")] string Role
);
