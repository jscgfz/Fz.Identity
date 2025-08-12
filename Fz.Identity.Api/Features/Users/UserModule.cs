using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Users.Commands.AddCredential;
using Fz.Identity.Api.Features.Users.Commands.AddUser;
using Fz.Identity.Api.Features.Users.Commands.UpdateUser;
using Fz.Identity.Api.Features.Users.Commands.UpdateUserApplicationCommand;
using Fz.Identity.Api.Features.Users.Commands.ValidateUser;
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

    group.MapGet("/{userId}", async (Guid userId, ISender sender) => await sender.Send(new UserQuery(userId)).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Obtiene un usuario existente por su id");

    group.MapPut("/{userId}", async (UpdateUserCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status204NoContent)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Actualiza un usuario existente por su id");

    group.MapPut("/{userId}/appliccations/{applicationId}", async (Guid userId, int applicationId, UpdateUserApplicationRequest body, ISender sender) => await sender.Send(new UpdateUserApplicationCommand(userId, applicationId, body.IsActive)).ToResult())
      .RequireAuthorization()
      .Produces(StatusCodes.Status204NoContent)
      .ProducesProblem(StatusCodes.Status409Conflict)
      .WithDescription("Actualiza el estado de un usuario en una aplicaión por su id");

    group.MapPost("/validate-user", async (ValidateUserCommand cmd, ISender sender) => await sender.Send(cmd).ToResult())
      .RequireAuthorization()
      .Produces<ValidateUserDto>()
      .WithDescription("Valida que un usuario exista y si pertence a un area, obtiene rol del usuario");
  }
}
