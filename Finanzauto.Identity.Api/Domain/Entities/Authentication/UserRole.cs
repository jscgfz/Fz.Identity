using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Authentication;

public class UserRole : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid UserId { get; set; }
  public Guid RoleId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }

  public virtual User User { get; set; } = null!;
  public virtual Role Role { get; set; } = null!;

  public UserRole(Guid userId, Guid roleId)
  {
    UserId = userId;
    RoleId = roleId;
  }

  public UserRole() { }
}
