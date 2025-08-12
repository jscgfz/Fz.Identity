using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Users.Commands.AddUser;

public sealed record AddUserCommand(
  string Name,
  string Surname,
  string UserName,
  string Email,
  string? IdentificationNumber,
  string? PhoneNamuber,
  string? DocumentType,
  List<Guid>? RoleIds,
  List<int> ApplicationIds,
  string? photoBase64,
  int? AreaId
) : ICommand<Result<UserAddedResponseDto>>;
