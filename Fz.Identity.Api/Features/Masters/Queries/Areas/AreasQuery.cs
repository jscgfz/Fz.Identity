using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Masters.Queries.Areas;

public class AreasQuery() : IQuery<Result<IEnumerable<AreaDto>>>;
