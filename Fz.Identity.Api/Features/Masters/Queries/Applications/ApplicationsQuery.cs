using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Masters.Queries.Applications;

public sealed record ApplicationsQuery(bool OnlyGroup = false) : IQuery<Result<IEnumerable<ApplicationDto>>>;
