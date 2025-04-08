using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Masters.Queries.CredentialTypes;

public sealed record CredentialTypesQuery() : IQuery<Result<IEnumerable<CredentialTypeDto>>>;
