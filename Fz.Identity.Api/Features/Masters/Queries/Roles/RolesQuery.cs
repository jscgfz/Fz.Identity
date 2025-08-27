using Fz.Core.Result.Extensions.Abstractions;
using Fz.Core.Result;
using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Masters.Queries.Roles;

public sealed record RolesQuery(int ApplicationId) : IQuery<Result<IEnumerable<RoleMasterDto>>>;
