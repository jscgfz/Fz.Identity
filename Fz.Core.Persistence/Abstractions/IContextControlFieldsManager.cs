namespace Fz.Core.Persistence.Abstractions;

public interface IContextControlFieldsManager<TUser>
  where TUser : IEquatable<TUser>
{
  DateTime UtcNow { get; }
  TUser CurrentUserId { get; }
}
