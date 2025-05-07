using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Users.Queries.UserById;

public sealed record UserQuery(Guid userId) : IQuery<Result<UserDto>>;
