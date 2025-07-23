using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Abstractions.Persistence;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;

namespace Finanzauto.Identity.Api.Domain.Entities.Authentication;

public class ApiKey : Entity<Guid>, IRootEntity
{
  public Guid AppId { get; set; }
  public string Consumer { get; set; }
  public byte[] ApiKeyHash { get; set; }
  public byte[] ApiKeySalt { get; set; }
  public bool IsRoot { get; set; }

  public virtual App App { get; set; } = default!;
  public virtual ICollection<ApiKeyClaim> Claims { get; set; } = default!;


  public ApiKey(Guid appId, string consumer, byte[] apiKeyHash, byte[] apiKeySalt, bool isRoot)
  {
    AppId = appId;
    Consumer = consumer;
    ApiKeyHash = apiKeyHash;
    ApiKeySalt = apiKeySalt;
    IsRoot = isRoot;
  }

#pragma warning disable CS8618
  public ApiKey() { }
#pragma warning restore CS8618
}
