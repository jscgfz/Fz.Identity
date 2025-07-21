using Azure;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using MediatR;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUserApplicationCommand;

public sealed record UpdateUserApplicationCommand(
  Guid UserId,
  int ApplicationId,
  bool IsActive
  ) : ICommand<Result>;
