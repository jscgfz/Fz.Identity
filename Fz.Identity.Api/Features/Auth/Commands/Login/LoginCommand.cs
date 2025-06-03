using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Auth.Dtos;
using System.Text.Json;

namespace Fz.Identity.Api.Features.Auth.Commands.Login;

public record class LoginCommand(int ApplicationId, int? CredentialType, JsonElement Credentials) : ICommand<Result<IdentityResponseDto>>;
