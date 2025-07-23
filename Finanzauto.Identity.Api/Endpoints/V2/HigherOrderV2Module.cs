using Finanzauto.Core.Web.Endpoints.Extensions;
using Finanzauto.Identity.Api.Configuration.Authentication;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using System.Reflection;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class HigherOrderV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder main = builder
//      .MapGroup("/-hoe-")
//      .RequireAuthorization(
//        PolicyBuilderFactory.HigherOrderEndpoint
//      )
//      .MapToApiVersion(2);

//    main.MapEnpointModulesFromAssemblies<IHigherOrderV2Module>(Assembly.GetExecutingAssembly());
//  }
//}
