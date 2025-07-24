using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;

namespace Fz.Identity.Api.Features.Requests.Commands.RejectRequest;

public sealed record RejectRequestCommand(int RequestId, string Reason) : ICommand<Result>;
