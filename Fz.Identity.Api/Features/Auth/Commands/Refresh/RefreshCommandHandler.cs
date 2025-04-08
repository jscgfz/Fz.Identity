using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Auth.Commands.Refresh;

public sealed class RefreshCommandHandler(IServiceProvider provider) : ICommandHandler<RefreshCommand, Result<IdentityResponseDto>>
{
  private readonly ITokenProviderService _tokenProviderService = provider.GetRequiredKeyedService<ITokenProviderService>(ContextTypes.Identity);
  public Task<Result<IdentityResponseDto>> Handle(RefreshCommand request, CancellationToken cancellationToken)
   => _tokenProviderService.RefreshToken();
}
