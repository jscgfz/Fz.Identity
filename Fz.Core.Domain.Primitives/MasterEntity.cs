namespace Fz.Core.Domain.Primitives;

public abstract class MasterEntity<TKey, TUser> : Entity<TKey, TUser>
  where TKey : IEquatable<TKey>
  where TUser : IEquatable<TUser>
{
#pragma warning disable CS8618
  public virtual string Name { get; set; }
  public virtual string Description { get; set; }
#pragma warning restore CS8618
}

public abstract class MasterEntity<TKey> : MasterEntity<TKey, Guid>
  where TKey : IEquatable<TKey>
{ }
