using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Commands.CreateApiKey;

public sealed class CreateApiKeyCommandHandler(IServiceProvider provider) : ICommandHandler<CreateApiKeyCommand, ApikeyResponseDto>
{
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();
  private readonly ISignatureKeyManager _signatureKeyManager = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IHashManager _hash = provider.GetRequiredService<IHashManager>();

  public async Task<Result<ApikeyResponseDto>> Handle(CreateApiKeyCommand request, CancellationToken cancellationToken)
  {
    App application = await _context.Repository<App>()
      .FirstAsync(row => row.Id == request.AppId, cancellationToken);

    string apikey = $"{application.Prefix}-{_signatureKeyManager.NewHexString().ToLower()}";

    return await _hash.ComputeHash(
      apikey,
      cancellationToken
    ).Map(result => Create(result, request, cancellationToken));
  }

  private async Task<ApikeyResponseDto> Create(HashResponse hash, CreateApiKeyCommand request, CancellationToken cancellationToken)
  {
    ApiKey apikey = new()
    {
      ApiKeyHash = hash.Hash,
      ApiKeySalt = hash.Salt,
      AppId = request.AppId,
      Consumer = request.Consumer
    };

    _context.Add(apikey);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return new(apikey.Id, hash.Data);
  }
}
