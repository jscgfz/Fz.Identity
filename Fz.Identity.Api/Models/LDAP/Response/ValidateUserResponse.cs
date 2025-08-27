using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record ValidateUserResponse(
  [property: JsonPropertyName("message")] MessageResponse Message,
  [property: JsonPropertyName("roles")] IEnumerable<UserAttributeResponse> Attributes
  );
