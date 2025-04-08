using Fz.Core.Domain.Primitives.Abstractions;

namespace Fz.Identity.Api.Database.Entities;

public class UserRole : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid UserId { get; set; }
  public Guid RoleId { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }
  public Guid ModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid DeletedBy { get; set; }

  public virtual Role Role { get; set; } = default!;
  public virtual User User { get; set; } = default!;
}