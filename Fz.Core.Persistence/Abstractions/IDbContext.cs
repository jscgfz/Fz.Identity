namespace Fz.Core.Persistence.Abstractions;

public interface IDbContext : IReadOnlyDbContext
{
  void Add<TQuery>(TQuery entity) where TQuery : class;
  void AddRange<TQuery>(IEnumerable<TQuery> entities) where TQuery : class;
  void Update<TQuery>(TQuery entity) where TQuery : class;
  void UpdateRange<TQuery>(IEnumerable<TQuery> entities) where TQuery : class;
  void Delete<TQuery>(TQuery entity) where TQuery : class;
  void DeleteRange<TQuery>(IEnumerable<TQuery> entities) where TQuery : class;
}
