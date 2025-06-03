using System.Text.Json;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public record CredentialDto(string UserName, string Password, int CredentialTypeId, Guid UserId);
