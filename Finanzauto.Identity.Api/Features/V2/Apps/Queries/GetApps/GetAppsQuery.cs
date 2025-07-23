using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApps;

public sealed record GetAppsQuery(
  int? PageIndex,
  int? PageSize,
  string? Filter,
  bool FullSet = false
) : IPaginationParams, IQuery<IPaginatedResult<AppDetailsDto>>;
