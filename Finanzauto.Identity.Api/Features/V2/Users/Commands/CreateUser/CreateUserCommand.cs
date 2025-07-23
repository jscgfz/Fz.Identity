using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;
using Finanzauto.Identity.Api.Models.Credential.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
  string? DocumentTypeId,
  string? DocumentNumber,
  string FirstName,
  string SecondName,
  string FirstLastName,
  string SecondLastName,
  string Email,
  string? PhoneNumber,
  string? Address,
  IEnumerable<Guid>? RoleIds,
  IEnumerable<CreateCredentialDto> Credentials
) : ICommand<CreatedUserDto>;
