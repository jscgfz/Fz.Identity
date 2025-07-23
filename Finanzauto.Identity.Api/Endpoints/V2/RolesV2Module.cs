using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Configuration.Authentication;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Roles.Dtos;
using Finanzauto.Identity.Api.Features.V2.Roles.Queries.GetRoles;
using MediatR;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class RolesV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder group = builder
//      .MapGroup("/roles")
//      .WithTags("roles")
//      .MapToApiVersion(2);

//    group
//      .MapGet(string.Empty, async ([AsParameters] GetRolesQuery query, ISender sender) => await sender.Send(query).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("roles:read")
//          .Build()
//      )
//      .Produces<IPaginatedResult<RoleDto>>()
//      .WithDescription("Obtiene los roles del sistema");
//  }
//}
