using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Roles.Commands.AddRole;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Roles.Queries.ActiveDirectoryRoles;
using Fz.Identity.Api.Features.Roles.Queries.RoleById;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    group.MapGet("/active-directory", async ([AsParameters] ActiveDirectoryRolesQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces<IEnumerable<ActiveDirectoryRoleDto>>()
      .WithDescription("Obtiene los roles del directorio activo");

    group.MapPost(string.Empty, async(AddRoleCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .WithDescription("Crea un nuevo rol en el sistema");

    group.MapGet("/{roleId}", async (Guid roleId, [AsParameters] RoleByIdQuery query , ISender sender) => await sender.Send(new RoleByIdQuery(roleId, query.IncludeAllModules)).ToResult())
      .RequireAuthorization()
      .Produces<RoleDetailDto>()
      .WithDescription("Obtiene rol por su id");
  }
}
