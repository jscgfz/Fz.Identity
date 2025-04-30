using Fz.Core.Domain.Primitives.Abstractions;

namespace Fz.Core.Persistence.Configuration;

public class DbConfigurationSection<TUser> : IBaseEntity<string>, IAuditableEntity<TUser>, ISoftDeleteableEntity<TUser>
  where TUser : IEquatable<TUser>
{
#pragma warning disable CS8618
  public string Id { get; set; }
  public string? Value { get; set; }
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

public class DbConfigurationSection : DbConfigurationSection<Guid> { }
