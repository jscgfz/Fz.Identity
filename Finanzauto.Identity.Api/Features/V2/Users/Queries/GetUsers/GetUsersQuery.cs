using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Users.Queries.GetUsers;

public sealed record GetUsersQuery(
  int? PageIndex,
  int? PageSize,
  string? Filter,
  bool FullSet = false
) : IPaginationParams, IQuery<IPaginatedResult<CreatedUserDto>>;
