using Fz.Core.Domain.Primitives.Abstractions;

namespace Fz.Core.Domain.Primitives;

public abstract class Entity<TKey, TUser> : IBaseEntity<TKey>, IAuditableEntity<TUser>, ISoftDeleteableEntity<TUser>
  where TKey : IEquatable<TKey>
  where TUser : IEquatable<TUser>
{
#pragma warning disable CS8618
  public TKey Id { get; set; }
#pragma warning restore CS8618
  public DateTime CreatedAtUtc { get; }
#pragma warning disable CS8618
  public TUser CreatedBy { get; }
#pragma warning restore CS8618
  public DateTime? ModifiedAtUtc { get; }
  public TUser? ModifiedBy { get; }
  public bool IsDeleted { get; }
  public DateTime? DeletedAtUtc { get; }
  public TUser? DeletedBy { get; }
}

public abstract class Entity<TKey> : Entity<TKey, Guid>
  where TKey : IEquatable<TKey>
{ }
