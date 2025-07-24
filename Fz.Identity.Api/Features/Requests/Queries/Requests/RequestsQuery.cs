using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;
using System;

namespace Fz.Identity.Api.Features.Requests.Queries.Requests;

public sealed record RequestsQuery(
  int? Id,
  DateTime? DateFrom,
  DateTime? DateTo,
  int? ApplicationId,
  string? Reason,
  string? Status,
  int? PageIndex,
  int? PageSize,
  bool FullSet = false
  ) : PaginationParams(PageIndex, PageSize, FullSet), IQuery<Result<IPaginatedResult<RequestDto>>>;
