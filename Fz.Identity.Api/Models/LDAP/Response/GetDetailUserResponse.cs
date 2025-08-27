using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record GetDetailUserResponse(
  [property: JsonPropertyName("mensaje")] MessageResponse Message,
  [property: JsonPropertyName("detalles")] IEnumerable<UserAttributeResponse> Attributes,
  [property: JsonPropertyName("roles")] IEnumerable<UserAttributeResponse> Roles
  );
