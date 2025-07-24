using Fz.Core.Result.Extensions.Abstractions;
using Fz.Core.Result;

namespace Fz.Identity.Api.Features.Requests.Commands.ConfirmRequest;

public sealed record ConfirmRequestCommand(int RequestId) : ICommand<Result>;
