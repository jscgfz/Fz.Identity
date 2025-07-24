using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Features.Requests.Queries.RequestById;

public sealed record RequestByIdQuery(int Id) : IQuery<Result<RequestDetailDto>>;
