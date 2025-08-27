using System.Text.Json.Serialization;

namespace Fz.Identity.Api.Models.LDAP.Response;

public sealed record MessageResponse(
  [property: JsonPropertyName("codigoMensaje")] int Code,
  [property: JsonPropertyName("descMensaje")] string Description
  );
