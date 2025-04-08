using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using MediatR;

namespace Fz.Identity.Api.Features.Roles;

public sealed class RoleModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/roles")
      .WithTags("roles")
      .MapToApiVersion(1);

    group.MapGet(string.Empty, async ([AsParameters] RolesQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces<IEnumerable<RoleDto>>()
      .WithDescription("Obtiene los roles disponibles en el sistema");
  }
}
