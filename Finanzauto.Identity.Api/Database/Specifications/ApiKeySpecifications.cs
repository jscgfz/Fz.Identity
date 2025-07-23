using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Models.ApiKey;

namespace Finanzauto.Identity.Api.Database.Specifications;

public static class ApiKeySpecifications
{
  public static ISpecification<ApiKey, ApiKeyAtomicValues> AtomicValues =>
    new SpecificationBuilder<ApiKey, ApiKeyAtomicValues>()
      .WithInclude(row => row.App)
      .WithSelect(row => new ApiKeyAtomicValues(
        row.Id,
        row.Consumer,
        row.ApiKeyHash,
        row.ApiKeySalt,
        row.CreatedAtUtc,
        row.App.Id,
        row.App.ApplicationName,
        row.App.Description,
        row.App.MultiDomainEnabled,
        row.App.RootApplicationEnabled,
        row.App.TwoFactorEnabled
      ));
}
