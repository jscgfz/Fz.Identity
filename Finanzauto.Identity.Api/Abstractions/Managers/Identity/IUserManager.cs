using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;

namespace Finanzauto.Identity.Api.Abstractions.Managers.Identity;

public interface IUserManager
{
  Task<Result<CreatedUserDto>> CreateUser(CreateUserCommand cmd, CancellationToken cancellationToken);
}
