using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Roles.Queries.ActiveDirectoryRoles;

public sealed record ActiveDirectoryRolesQuery(Guid? IncludeId) : IQuery<Result<IEnumerable<ActiveDirectoryRoleDto>>>;
