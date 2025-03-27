namespace Fz.Core.Domain.Primitives.Abstractions;

public interface ISoftDeleteableEntity<TUser> where TUser : IEquatable<TUser>
{
  public bool IsDeleted { get; }
  public DateTime? DeletedAtUtc { get; }
  public TUser? DeletedBy { get; }
}
