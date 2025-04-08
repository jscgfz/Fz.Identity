using System.Text.Json;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public record CredentialDto(JsonElement Value, string UserName, string Password, int CredentialTypeId, Guid UserId);
