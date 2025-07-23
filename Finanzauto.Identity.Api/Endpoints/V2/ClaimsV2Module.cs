using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Claims.Commands.Actions;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;
using Finanzauto.Identity.Api.Features.V2.Claims.Queries.Values;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finanzauto.Identity.Api.Endpoints.V2;

public sealed class ClaimsV2Module : IIdentityModule
{
  public void RegisterEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/claims")
      .WithTags("claims")
      .MapToApiVersion(2);

    group
      .MapPost("/actions", async (ClaimActionsCommand cmd, ISender sender) => await sender.Send(cmd).AsResult())
      .Produces<IEnumerable<ClaimResponseDto>>()
      .WithDescription("Agrega o modifica las acciones de los privilegios");

    group
      .MapGet(string.Empty, async ([AsParameters] ClaimValuesQuery query, ISender sender) => await sender.Send(query).AsResult())
      .Produces<IPaginatedResult<FullClaimDto>>()
      .WithDescription("Obtiene los privilegios disponibles del sistema");
  }
}
