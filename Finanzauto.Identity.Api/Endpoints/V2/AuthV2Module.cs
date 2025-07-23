using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.RefreshToken;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;
using MediatR;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class AuthV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder group = builder
//      .MapGroup("/auth")
//      .WithTags("auth")
//      .MapToApiVersion(2);

//    group
//      .MapPost("/login", (LoginCommand cmd, ISender sender) => sender.Send(cmd).AsResult())
//      .AllowAnonymous()
//      .Produces<TokenResponseDto>()
//      .WithDescription("Autentica un usuario y devuelve un token JWT");

//    group
//      .MapPost("/refresh", async (HttpRequest req) => 
//        await req.HttpContext.RequestServices.GetRequiredService<ISender>().Send(RefreshTokenCommand.Instance).AsResult())
//      .RequireAuthorization()
//      .Produces<TokenResponseDto>()
//      .WithDescription("Refresca la sesión");
//  }
//}
