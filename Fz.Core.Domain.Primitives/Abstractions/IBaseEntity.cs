namespace Fz.Core.Domain.Primitives.Abstractions;

public interface IBaseEntity<TKey> where TKey : IEquatable<TKey>
{
  TKey Id { get; }
}
