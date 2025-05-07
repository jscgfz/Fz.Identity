using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Users.Commands.AddCredential;
using Fz.Identity.Api.Features.Users.Commands.AddUser;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.UserById;
using Fz.Identity.Api.Features.Users.Queries.Users;
using MediatR;

namespace Fz.Identity.Api.Features.Users;

public sealed class UserModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/users")
      .WithTags("users")
      .MapToApiVersion(1);

    group.MapPost(string.Empty, async (AddUserCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .Produces<UserAddedResponseDto>()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet(string.Empty, async ([AsParameters] UsersQuery query, ISender sender) => await sender.Send(query).ToResult())
      .RequireAuthorization()
      .Produces<IPaginatedResult<UserDto>>()
      .WithDescription("Lista los usuarios según los criterios");

    group.MapPost("/credentials", async (AddCredentialCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status201Created)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Agrega una credencial a un usuario existente");

    group.MapPost("/{userId}", async (Guid userId, ISender sender) => await sender.Send(new UserQuery(userId)).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status201Created)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Obtiene un usuario existente por su id");
  }
}
