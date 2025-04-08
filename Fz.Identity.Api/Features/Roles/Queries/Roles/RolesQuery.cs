using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Roles.Queries.Roles;

public sealed record RolesQuery(int? ApplicationId) : IQuery<Result<IEnumerable<RoleDto>>>;
