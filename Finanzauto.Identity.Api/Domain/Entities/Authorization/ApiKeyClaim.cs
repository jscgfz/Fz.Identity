using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Claims;

namespace Finanzauto.Identity.Api.Domain.Entities.Authorization;

public class ApiKeyClaim : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid ApiKeyId { get; set; }
  public Guid ClaimValueId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }

  public virtual ApiKey ApiKey { get; set; } = default!;
  public virtual ClaimValue ClaimValue { get; set; } = default!;

  public ApiKeyClaim(Guid apiKeyId, Guid claimValueId)
  {
    ApiKeyId = apiKeyId;
    ClaimValueId = claimValueId;
  }

  public ApiKeyClaim()
  {
  }
}
