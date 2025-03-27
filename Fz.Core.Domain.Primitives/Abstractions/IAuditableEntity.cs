namespace Fz.Core.Domain.Primitives.Abstractions;

public interface IAuditableEntity<TUser> where TUser : IEquatable<TUser>
{
  DateTime CreatedAtUtc { get; }
  TUser CreatedBy { get; }
  DateTime? ModifiedAtUtc { get; }
  TUser? ModifiedBy { get; }
}
