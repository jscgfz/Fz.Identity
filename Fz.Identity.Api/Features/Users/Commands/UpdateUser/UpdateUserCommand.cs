using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;

namespace Fz.Identity.Api.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(
  Guid id,
  string Name,
  string Surname,
  string Email,
  string IdentificationNumber,
  string PhoneNamuber,
  string DocumentType,
  string UserName,
  List<Guid> RoleIds
  ) : ICommand<Result>;
