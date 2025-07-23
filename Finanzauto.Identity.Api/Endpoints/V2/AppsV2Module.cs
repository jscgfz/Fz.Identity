using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApp;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Commands.CreateApiKey;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Query.VerifyApiKey;
using Finanzauto.Identity.Api.Features.V2.Apps.Commands.CreateApp;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApps;
using MediatR;
using Finanzauto.Identity.Api.Configuration.Authentication;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class AppsV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder group = builder
//      .MapGroup("/apps")
//      .WithTags("apps")
//      .MapToApiVersion(2);

//    group
//      .MapPost(string.Empty, async (CreateAppCommand cmd, ISender sender) => await sender.Send(cmd).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("apps:create")
//          .ValidateSuperUser()
//          .Build()
//      )
//      .Produces<AppCreatedDto>()
//      .WithDescription("crea una app");

//    group
//      .MapGet(string.Empty, async ([AsParameters] GetAppsQuery query, ISender sender) => await sender.Send(query).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("apps:read")
//          .ValidateSuperUser()
//          .Build()
//      )
//      .Produces<IPaginatedResult<AppDetailsDto>>()
//      .WithDescription("Obtiene el detalle de las aplicaciones del sistema");

//    group
//      .MapGet("/{Id}", (Guid Id, ISender sender) => sender.Send(new GetAppQuery(Id)).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("apps:read")
//          .ValidateSuperUser()
//          .Build()
//      )
//      .Produces<AppDetailsDto>()
//      .WithDescription("Obtiene el detalle de la aplicación del sistema");

//    group
//      .MapPost("/apikeys", (CreateApiKeyCommand cmd, ISender sender) => sender.Send(cmd).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("apikeys:create")
//          .ValidateSuperUser()
//          .Build()
//      )
//      .Produces<ApikeyResponseDto>()
//      .WithDescription("Genera un apikey de consumo para aplicaciones");

//    group
//      .MapPost("/apikeys/verify", async (VerifyApiKeyQuery query, ISender sender) => await sender.Send(query).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("apikeys:download")
//          .ValidateSuperUser()
//          .Build()
//      )
//      .Produces<ApikeyDetailsDto>()
//      .WithDescription("Verifica la autenticidad del api key");
//  }
//}
