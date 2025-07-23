using Finanzauto.Identity.Api.Endpoints.Configuration;

namespace Finanzauto.Identity.Api.Endpoints.V2.HigherOrder;

public sealed class ActiveDirectoryV2Module : IHigherOrderV2Module
{
  public void RegisterEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/active-directory")
      .WithTags("-hoe-active-directory");

    group
      .MapGet(string.Empty, () => new { Response = "Ok" });
  }
}
