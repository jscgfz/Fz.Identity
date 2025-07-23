using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.RefreshToken;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;
using Finanzauto.Identity.Api.Models.Authentication.Dtos;
using MediatR;

namespace Finanzauto.Identity.Api.Endpoints.V1;

public sealed class AuthV1Module : IIdentityModule
{
  public void RegisterEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/auth")
      .WithTags("auth")
      .MapToApiVersion(1);

    group
      .MapPost("/login", (LoginV1Command cmd, ISender sender) => sender.Send(new LoginCommand(cmd.Credentials.UserName, cmd.Credentials.Password, null, cmd.ApplicationId)).AsResult())
      .Produces<TokenResponseDto>()
      .WithDescription("Autentica un usuario y devuelve un token JWT");

    group
      .MapPost("/refresh", async (HttpRequest req) =>
        await req.HttpContext.RequestServices.GetRequiredService<ISender>().Send(RefreshTokenCommand.Instance).AsResult())
      .RequireAuthorization()
      .Produces<TokenResponseDto>()
      .WithDescription("Refresca la sesión");
  }
}
