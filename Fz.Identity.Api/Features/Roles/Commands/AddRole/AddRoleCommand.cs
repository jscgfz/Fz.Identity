using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Features.Roles.Commands.AddRole;

public sealed record AddRoleCommand(
  string Name,
  string ActiveDirectoryRole,
  IEnumerable<ModuleDto> Modules
  ): ICommand<Result>;
