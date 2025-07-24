using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;

namespace Fz.Identity.Api.Features.Requests.Commands.AddRequest;

public sealed record AddRequestCommand(
  Guid ResourceId,
  string Reason,
  IFormFile AuthorizationFile,
  string ChangesJson
  ) : ICommand<Result>
{
}
