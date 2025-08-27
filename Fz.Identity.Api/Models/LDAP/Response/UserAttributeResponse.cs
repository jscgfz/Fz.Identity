using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record UserAttributeResponse(
  [property: JsonPropertyName("descripcion")] string Description
  );
