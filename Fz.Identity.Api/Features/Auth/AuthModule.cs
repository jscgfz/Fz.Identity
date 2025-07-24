using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Auth.Commands.Login;
using Fz.Identity.Api.Features.Auth.Commands.Refresh;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Auth.Queries.Modules;
using Fz.Identity.Api.Features.Auth.Queries.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fz.Identity.Api.Features.Auth;

public sealed class AuthModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/auth")
      .WithTags("auth")
      .MapToApiVersion(1);

    group
      .MapPost("/login", async (LoginCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .AllowAnonymous()
      .Produces<IdentityResponseDto>()
      .WithDescription("Obtiene el token de acceso a los endpoints del sistema");

    group
      .MapPost("/refresh", async (RefreshCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .Produces<IdentityResponseDto>()
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithDescription("Refresca el token de acceso a los endpoints del sistema");

    group
      .MapGet("/routes", async ([FromServices] ISender sender) => await sender.Send(new RoutesQuery()).ToResult())
      .RequireAuthorization()
      .Produces<IEnumerable<RouteDto>>()
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithDescription("Obtiene las rutas configuradas para el usuario");

    group
      .MapGet("/modules", async ([FromServices] ISender sender) => await sender.Send(new ModulesQuery()).ToResult())
      .RequireAuthorization()
      .Produces<IEnumerable<ModuleDto>>()
      .WithDescription("Obtiene los modulos configurados");
  }
}
