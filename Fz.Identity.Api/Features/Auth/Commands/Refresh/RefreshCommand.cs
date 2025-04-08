using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Features.Auth.Commands.Refresh;

public sealed record RefreshCommand() : ICommand<Result<IdentityResponseDto>>;
