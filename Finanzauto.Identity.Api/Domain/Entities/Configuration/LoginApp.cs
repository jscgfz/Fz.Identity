using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;

namespace Finanzauto.Identity.Api.Domain.Entities.Configuration;

public class LoginApp : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid AppId { get; set; }
  public int LoginTypeId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }
  public virtual App App { get; set; } = default!;
  public virtual LoginType LoginType { get; set; } = default!;

  public LoginApp(Guid appId, int loginTypeId)
  {
    AppId = appId;
    LoginTypeId = loginTypeId;
  }

#pragma warning disable CS8618
  public LoginApp() { }
#pragma warning restore CS8618
}
