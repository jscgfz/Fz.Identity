using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Managements.Queries;
using Fz.Identity.Api.Features.Users.Commands.AddCredential;
using MediatR;

namespace Fz.Identity.Api.Features.Managements;

public sealed class ManagementModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/managements")
      .WithTags("managements")
      .MapToApiVersion(1);

    group.MapGet(string.Empty, async ([AsParameters] ManagementsQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Obtiene el historico de gestiones");
  }
}
