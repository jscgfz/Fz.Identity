using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Users.Commands.AddCredential;

public sealed record AddCredentialCommand(Guid UserId, CredentialTypes Type, string? Username) : ICommand<Result>;
