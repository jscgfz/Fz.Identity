using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Features.Auth.Queries.Modules;

public sealed record ModulesQuery() : IQuery<Result<IEnumerable<ModuleDto>>>;
