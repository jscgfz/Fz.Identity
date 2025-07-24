using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Requests.Commands.AddRequest;
using Fz.Identity.Api.Features.Requests.Commands.ApproveRerquest;
using Fz.Identity.Api.Features.Requests.Commands.RejectRequest;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Requests.Queries.AuthorizationFileById;
using Fz.Identity.Api.Features.Requests.Queries.RequestById;
using Fz.Identity.Api.Features.Requests.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using Fz.Identity.Api.Security;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Features.Requests.Commands.ConfirmRequest;
using Fz.Identity.Api.Features.Requests.Queries.RequestRejectionById;

namespace Fz.Identity.Api.Features.Requests;

public class RequestModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/requests")
      .WithTags("requests")
      .MapToApiVersion(1);

    group.MapPost(string.Empty, async ([FromForm] AddRequestCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .WithMetadata(IgnoreAntiforgeryMetadata.Instance)
      .RequireAuthorization()
      .WithDescription("Crea una solicitud de edición");

    group.MapGet("/{requestId}", async (int requestId, ISender sender) => await sender.Send(new RequestByIdQuery(requestId)).ToResult())
      .RequireAuthorization()
      .Produces<RequestDetailDto>()
      .WithDescription("Obtiene una solicitud por id");

    group.MapPatch("/{requestId}/reject", async ([FromBody] RejectRequestCommand cmd, int requestId, ISender sender) =>
    {
      if (requestId != cmd.RequestId)
        return Results.BadRequest("El ID de la URL no coincide con el del cuerpo.");

      return await sender.Send(cmd).ToResult();
    })
      .RequireAuthorization()
      .Produces<RequestDetailDto>()
      .WithDescription("Rechaza una solicitud por id");

    group.MapPatch("/{requestId}/approve", async (int requestId, ISender sender) => await sender.Send(new ApproveRequestCommand(requestId)).ToResult())
      .RequireAuthorization()
      .Produces<RequestDetailDto>()
      .WithDescription("Aprueba una solicitud por id");

    group.MapGet(string.Empty, async ([AsParameters] RequestsQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces<IPaginatedResult<RequestDto>>()
      .WithDescription("Lista de solicitudes según los criterios");

    group.MapGet("/{requestId}/authorization-file", async (int requestId, ISender sender) =>
    {
      var result = await sender.Send(new AuthorizationFileByIdQuery(requestId));

      if (result.Type.Equals(ResultTypes.BadRequest))
        return result.ToResult();

      if(result.Type.Equals(ResultTypes.NotFound))
        return result.ToResult();

      return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
    })
      .RequireAuthorization()
      .WithDescription("Obtiene el archivo de autorización de la solicitud solicitada");

    group.MapPatch("/{requestId}/confirm", async (int requestId, ISender sender) => await sender.Send(new ConfirmRequestCommand(requestId)).ToResult())
      .RequireAuthorization()
      .WithDescription("Confirma una solicitud por su id");

    group.MapGet("/{requestId}/rejection", async (int requestId, ISender sender) => await sender.Send(new RequestRejectionByIdQuery(requestId)).ToResult())
      .RequireAuthorization()
      .Produces<RequestRejectionDto>()
      .WithDescription("Obtiene datos de rechazo de una solicitud por su id");
     ;
  }
}
