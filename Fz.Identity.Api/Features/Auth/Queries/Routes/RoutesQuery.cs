using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Features.Auth.Queries.Routes;

public sealed record RoutesQuery() : IQuery<Result<IEnumerable<RouteDto>>>;
