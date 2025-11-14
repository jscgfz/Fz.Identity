using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Reports.Queries.FullLoginReport;
using MediatR;

namespace Fz.Identity.Api.Features.Reports;

public sealed class ReportsModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/reports")
      .WithTags("reports")
      .MapToApiVersion(1);

    group.MapGet("/users/connectivity/details",
      async ([AsParameters] FullLoginReportQuery query, ISender sender) => await sender.Send(query).ToResult());

    group.MapGet("/users/connectivity/resume",
      async ([AsParameters] FullLoginReportQuery query, ISender sender) => await sender.Send(query).ToResult());
  }
}
