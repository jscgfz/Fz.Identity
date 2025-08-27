using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record GetRolesResponse(
  [property: JsonPropertyName("message")] MessageResponse Message,
  [property: JsonPropertyName("data")] IEnumerable<RoleResponse> Roles
  );