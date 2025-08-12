using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Requests.Queries.Requests;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Requests;

public sealed class RequestSpecification
{
  public static ISpecification<Request, RequestDto> ByRequestsQuery(RequestsQuery query)
    => new Specification<Request, RequestDto>()
    .WithFilter(row => !query.Id.HasValue || row.Id == query.Id)
    .WithAndFilter(row => (!query.DateFrom.HasValue || row.CreatedAtUtc.Date >= query.DateFrom.Value.Date) && (!query.DateTo.HasValue || row.CreatedAtUtc.Date <= query.DateTo.Value.Date))
    .WithAndFilter(row => !query.ApplicationId.HasValue || row.ApplicationId == query.ApplicationId)
    .WithAndFilter(row => string.IsNullOrEmpty(query.Reason) || row.Reason.Contains(query.Reason))
    .WithAndFilter(row => string.IsNullOrEmpty(query.Status) || row.Status.Name.Contains(query.Status))
    .WithInclude(row => row.Status)
    .WithInclude(row => row.Application)
    .WithOrderByDesc(row => row.CreatedAtUtc)
    .WithSelect(row => new(
      row.Id,
      row.CreatedAtUtc.ToString("dd/MM/yyyy hh:mm tt"),
      row.Application.Name,
      null,
      row.Reason,
      row.Status.Name,
      row.StatusId != (int)RequestStatuses.Pending ? null : RequestDetailDto.GettRemainingTime(row.ExpireAt),
      row.CreatedBy
      ));
}
