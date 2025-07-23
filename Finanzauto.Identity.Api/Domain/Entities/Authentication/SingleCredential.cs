using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Authentication;

public class SingleCredential : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid UserId { get; set; }
  public Guid AppId { get; set; }
  public string UserName { get; set; }
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }

  public virtual User User { get; set; } = default!;
  public virtual App Application { get; set; } = default!;

  public SingleCredential(
    Guid userId,
    Guid appId,
    string userName,
    byte[] passwordHash,
    byte[] passwordSalt
  )
  {
    UserId = userId;
    AppId = appId;
    UserName = userName;
    PasswordHash = passwordHash;
    PasswordSalt = passwordSalt;
  }

#pragma warning disable CS8618
  public SingleCredential() { }
#pragma warning restore CS8618
}
