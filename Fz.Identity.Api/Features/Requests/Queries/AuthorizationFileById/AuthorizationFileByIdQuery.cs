using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Features.Requests.Queries.AuthorizationFileById;

public sealed record AuthorizationFileByIdQuery(int RequestId) : IQuery<Result<FileDto>>;
