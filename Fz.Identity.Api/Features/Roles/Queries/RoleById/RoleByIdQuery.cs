using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Roles.Queries.RoleById;

public sealed record RoleByIdQuery(
  Guid Id
  ) : IQuery<Result<RoleDetailDto>>;
