using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginType;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginTypes;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;
using MediatR;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class LoginsV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder group = builder
//      .MapGroup("/logins")
//      .WithTags("logins")
//      .MapToApiVersion(2);

//    group
//      .MapGet("/types", async (HttpRequest req) =>
//        await req.HttpContext.RequestServices.GetRequiredService<ISender>().Send(new GetLoginTypesQuery()).AsResult())
//      .RequireAuthorization()
//      .Produces<IEnumerable<LoginTypeOptionDto>>()
//      .WithDescription("Obtiene los tipos de login disponibles en el sistema");

//    group
//      .MapGet("/types/{Id}", async (int Id, HttpRequest req) =>
//        await req.HttpContext.RequestServices.GetRequiredService<ISender>().Send(new GetLoginTypeQuery(Id)).AsResult())
//      .RequireAuthorization()
//      .Produces<LoginTypeDetailDto>()
//      .WithDescription("Obtiene el detalle de un tipo de login por su Id");
//  }
//}
