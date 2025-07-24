using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;

namespace Fz.Identity.Api.Features.Requests.Commands.ApproveRerquest;

public sealed record ApproveRequestCommand(int RequestId) : ICommand<Result>;
