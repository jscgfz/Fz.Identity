using Fz.Core.Domain.Primitives.Abstractions;

namespace Fz.Core.Domain.Primitives;

public abstract class Entity<TKey, TUser> : IBaseEntity<TKey>, IAuditableEntity<TUser>, ISoftDeleteableEntity<TUser>
  where TKey : IEquatable<TKey>
  where TUser : IEquatable<TUser>
{
#pragma warning disable CS8618
  public TKey Id { get; set; }
#pragma warning restore CS8618
  public DateTime CreatedAtUtc { get; set; }
#pragma warning disable CS8618
  public TUser CreatedBy { get; set; }
#pragma warning restore CS8618
  public DateTime? ModifiedAtUtc { get; set; }
  public TUser? ModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public TUser? DeletedBy { get; set; }
}

public abstract class Entity<TKey> : Entity<TKey, Guid>
  where TKey : IEquatable<TKey>
{ }
