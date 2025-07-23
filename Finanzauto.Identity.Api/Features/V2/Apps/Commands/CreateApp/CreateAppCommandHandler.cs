using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Finanzauto.Identity.Api.Models.Settings.Security;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Commands.CreateApp;

public sealed class CreateAppCommandHandler(IServiceProvider provider) : ICommandHandler<CreateAppCommand, AppCreatedDto>
{
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly ISignatureKeyManager _signatureKeyManager = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IAppConfigurationManager _configuration = provider.GetRequiredService<IAppConfigurationManager>();
  private JsonWebTokenSettings _jwtSettings => _configuration
    .Get<JsonWebTokenSettings>()!;


  public async Task<Result<AppCreatedDto>> Handle(CreateAppCommand request, CancellationToken cancellationToken)
  {
    App application = new()
    {
      ApplicationName = request.Name,
      Description = request.Description,
      DomainName = request.DomainName,
      Prefix = request.Prefix,
      RootApplicationEnabled = request.RootAppEnabled,
      MultiDomainEnabled = request.MultiDomainEnabled,
      TwoFactorEnabled = request.TwoFactorAuthenticationEnabled
    };

    _context.Add(application);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    AppSafety safety = new()
    {
      AppId = application.Id,
      ExpirationTime = request.TokenExpirationTime ?? _jwtSettings.TokenExpirationTime,
      RefreshExpirationTime = request.RefreshTokenExpirationTime ?? _jwtSettings.RefreshTokenExpirationTime,
      SignautreKey = _signatureKeyManager.New()
    };

    _context.Add(safety);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return new AppCreatedDto(
      application.Id,
      safety.SignautreKey,
      safety.ExpirationTime,
      safety.RefreshExpirationTime
    );
  }
}
