using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;
using Finanzauto.Identity.Api.Models.ApiKey;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Query.VerifyApiKey;

public sealed class VerifyApiKeyQueryHandler(IServiceProvider provider) : IQueryHandler<VerifyApiKeyQuery, ApikeyDetailsDto>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();
  private readonly IHashManager _hash = provider.GetRequiredService<IHashManager>();

  public async Task<Result<ApikeyDetailsDto>> Handle(VerifyApiKeyQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<ApiKeyAtomicValues> atomicValues = await ApiKeySpecifications.AtomicValues
      .Apply(_context.Repository<ApiKey>())
      .ToListAsync(cancellationToken);

    IEnumerable<Result<ApikeyDetailsDto>> results = await Task.WhenAll(
      atomicValues
        .Select(value => _hash.ValidateHash(
          new HashRequest(request.ApiKey, value.Hash, value.Salt),
          cancellationToken,
          new Error("ApiKey.Invalid", "Api key invalida")
        ).Map(result => new ApikeyDetailsDto(
          value.Id,
          value.Consumer,
          value.CreatedAtUtc,
          new AppDetailsDto(
            value.AppId,
            value.AppName,
            value.AppDescription,
            value.MultiDomainEnabled,
            value.RootApplicationEnabled,
            value.TwoFactorAuthenticationEnabled,
            null
          )
        )))
    );

    return results.Any(v => v.IsSucces) ? results.First(v => v.IsSucces) : results.First();
  }
}
