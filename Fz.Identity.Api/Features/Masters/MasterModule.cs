using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Features.Masters.Queries.Applications;
using Fz.Identity.Api.Features.Masters.Queries.Areas;
using Fz.Identity.Api.Features.Masters.Queries.CredentialTypes;
using MediatR;

namespace Fz.Identity.Api.Features.Masters;

public sealed class MasterModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/masters")
      .WithTags("masters")
      .MapToApiVersion(1);

    group
      .MapGet("/credential-types", async ([AsParameters] CredentialTypesQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces<IEnumerable<CredentialTypeDto>>()
      .WithDescription("Obtiene los tipos de credenciales disponibles en el sistema");

    group
      .MapGet("/applications", async ([AsParameters] ApplicationsQuery query, ISender sender) => await sender.Send(query).ToResult())
      .AllowAnonymous()
      .Produces<IEnumerable<ApplicationDto>>()
      .WithDescription("Obtiene las aplicaciones disponibles en el sistema");

    group
      .MapGet("/areas", async ([AsParameters] AreasQuery query, ISender sender) => await sender.Send(query).ToResult())
      .AllowAnonymous()
      .Produces<IEnumerable<AreaDto>>()
      .WithDescription("Obtiene las aplicaciones disponibles en el sistema");
  }
}
