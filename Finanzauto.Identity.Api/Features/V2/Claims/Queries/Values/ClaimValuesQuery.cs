using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Queries.Values;

public sealed record ClaimValuesQuery(
  int? PageIndex,
  int? PageSize,
  bool FullSet = false
) : IPaginationParams, IQuery<IPaginatedResult<FullClaimDto>>;
