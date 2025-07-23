using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers.Identity;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(IServiceProvider provider) : ICommandHandler<CreateUserCommand, CreatedUserDto>
{
  private readonly IUserManager _user = provider.GetRequiredService<IUserManager>();

  public Task<Result<CreatedUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    => _user.CreateUser(request, cancellationToken);
}
