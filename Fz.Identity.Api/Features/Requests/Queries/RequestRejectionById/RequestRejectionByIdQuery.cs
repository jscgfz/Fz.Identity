using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Features.Requests.Queries.RequestRejectionById;

public sealed record RequestRejectionByIdQuery(int RequestId) : IQuery<Result<RequestRejectionDto>>;
