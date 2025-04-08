using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Identity;

namespace Fz.Identity.Api.Features.Users.Commands.AddCredential;

public sealed class AddCredentialCommandHandler(IServiceProvider provider) : ICommandHandler<AddCredentialCommand, Result>
{
  private readonly IServiceProvider _provider = provider;

  public Task<Result> Handle(AddCredentialCommand request, CancellationToken cancellationToken)
    => _provider.GetRequiredKeyedService<ICredentialValidatorService>(request.Type)
      .CreateCredential(request.UserId, request.Username!);
}
