using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Common.Mappers;
using Fz.Identity.Api.Features.Files.Commands.ExportFile;
using Fz.Identity.Api.Features.Managements.Queries;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Requests.Queries.Requests;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using Fz.Identity.Api.Features.Users.Commands.AddUser;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.Users;
using MediatR;

namespace Fz.Identity.Api.Features.Files;

public sealed class FileModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/files")
      .WithTags("files")
      .MapToApiVersion(1);

    group.MapGet("/users", async ([AsParameters] UsersQuery query, ISender sender) =>
    {
      var result = await sender.Send(new ExportFileCommand("usuarios", query));
      if (result.Type.Equals(ResultTypes.BadRequest))
      return result.ToResult();

      if (result.Type.Equals(ResultTypes.NotFound))
        return result.ToResult();

      return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
  })
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/roles", async ([AsParameters] RolesQuery query, ISender sender) =>
    {
      var result = await sender.Send(new ExportFileCommand("roles", query));
      if (result.Type.Equals(ResultTypes.BadRequest))
        return result.ToResult();

      if (result.Type.Equals(ResultTypes.NotFound))
        return result.ToResult();

      return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
    })
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/managements", async ([AsParameters] ManagementsQuery query, ISender sender) =>
    {
      var result = await sender.Send(new ExportFileCommand("gestiones", query));
      if (result.Type.Equals(ResultTypes.BadRequest))
        return result.ToResult();

      if (result.Type.Equals(ResultTypes.NotFound))
        return result.ToResult();

      return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
    })
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/requests", async ([AsParameters] RequestsQuery query, ISender sender) =>
    {
      var result = await sender.Send(new ExportFileCommand("solicitudes", query));
      if (result.Type.Equals(ResultTypes.BadRequest))
        return result.ToResult();

      if (result.Type.Equals(ResultTypes.NotFound))
        return result.ToResult();

      return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
    })
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");
  }
}
