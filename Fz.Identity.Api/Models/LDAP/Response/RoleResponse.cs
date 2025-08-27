using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record RoleResponse(
  [property: JsonPropertyName("name")] string Name 
  );
