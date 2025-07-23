using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result.Http.Extensions;
using Finanzauto.Identity.Api.Configuration.Authentication;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;
using Finanzauto.Identity.Api.Features.V2.Users.Queries.GetUsers;
using MediatR;

namespace Finanzauto.Identity.Api.Endpoints.V2;

//public sealed class UsersV2Module : IIdentityModule
//{
//  public void RegisterEndpoints(IEndpointRouteBuilder builder)
//  {
//    RouteGroupBuilder group = builder
//      .MapGroup("/users")
//      .WithTags("users")
//      .MapToApiVersion(2);

//    group
//      .MapPost(string.Empty, async (CreateUserCommand cmd, ISender sender) => await sender.Send(cmd).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("users:create")
//          .Build()
//      )
//      .Produces<CreatedUserDto>()
//      .WithDescription("Crea un usuario en el sistema");

//    group
//      .MapGet(string.Empty, async ([AsParameters] GetUsersQuery query, ISender sender) => await sender.Send(query).AsResult())
//      .RequireAuthorization(
//        PolicyBuilderFactory.Empty
//          .ValidateClaims("users:read")
//          .Build()
//      )
//      .Produces<IPaginatedResult<CreatedUserDto>>()
//      .WithDescription("Obtiene una lista de usuarios del sistema");
//  }
//}
