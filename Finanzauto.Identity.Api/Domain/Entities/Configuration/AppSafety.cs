using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;

namespace Finanzauto.Identity.Api.Domain.Entities.Configuration;

public class AppSafety : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid AppId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }
  public byte[] SignautreKey { get; set; }
  public TimeSpan ExpirationTime { get; set; }
  public TimeSpan RefreshExpirationTime { get; set; }

  public virtual App App { get; set; } = default!;

  public AppSafety(Guid appId, byte[] signautreKey, TimeSpan expirationTime, TimeSpan refreshExpirationTime)
  {
    AppId = appId;
    SignautreKey = signautreKey;
    ExpirationTime = expirationTime;
    RefreshExpirationTime = refreshExpirationTime;
  }

#pragma warning disable CS8618
  public AppSafety() { }
#pragma warning restore CS8618
}
