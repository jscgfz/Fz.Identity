using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Features.Files.Commands.ExportFile;
using Fz.Identity.Api.Features.Managements.Queries;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Requests.Queries.Requests;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.Users;
using MediatR;

namespace Fz.Identity.Api.Features.Files;

public sealed class FileModule : IIdentityModule
{
  public void MapEndpoints(IEndpointRouteBuilder builder)
  {
    RouteGroupBuilder group = builder
      .MapGroup("/files")
      .WithTags("files")
      .MapToApiVersion(1);

    group.MapGet("/users", async ([AsParameters] UsersQuery query, ISender sender) => await Process(sender, query))
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/roles", async ([AsParameters] RolesQuery query, ISender sender) => await Process(sender, query))
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/managements", async ([AsParameters] ManagementsQuery query, ISender sender) => await Process(sender, query))
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");

    group.MapGet("/requests", async ([AsParameters] RequestsQuery query, ISender sender) => await Process(sender, query))
      .RequireAuthorization()
      .WithDescription("Crea un nuevo usuario en el sistema");
  }

  private static IResult SetResult(Result<FileDto> result)
  {
    if (result.Type.Equals(ResultTypes.BadRequest))
      return result.ToResult();

    if (result.Type.Equals(ResultTypes.NotFound))
      return result.ToResult();

    return Results.File(result.Value.FileBytes, result.Value.ContentType, result.Value.Name);
  }

  private static async Task<IResult> Process<TRow>(ISender sender, IQuery<Result<IPaginatedResult<TRow>>> query)
    where TRow : class
  {
    Result<FileDto> result = await sender.Send(query)
        .Map(result => sender.Send(new ExportFileCommand(result.Data)));

    return SetResult(result);
  }
}
