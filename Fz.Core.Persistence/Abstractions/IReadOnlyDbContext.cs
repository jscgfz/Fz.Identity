using System.Linq.Expressions;

namespace Fz.Core.Persistence.Abstractions;

public interface IReadOnlyDbContext : IDbSpecificationContext
{
  IQueryable<TQuery> Repository<TQuery>() where TQuery : class;
  ValueTask<TQuery?> FindByIdAsync<TQuery>(params object[] keys) where TQuery : class;
  Task<TQuery?> FirstOrDefaultAsync<TQuery>(Expression<Func<TQuery, bool>> predicate) where TQuery : class;
  Task<IEnumerable<TQuery>> ListAsync<TQuery>(Expression<Func<TQuery, bool>> predicate) where TQuery : class;
  Task<int> CountAsync<TQuery>(Expression<Func<TQuery, bool>> predicate) where TQuery : class;
  Task<bool> AnyAsync<TQuery>(Expression<Func<TQuery, bool>> predicate) where TQuery : class;
}
