namespace Fz.Core.Persistence.Abstractions;

public interface IDbSpecificationContext
{
  Task<TResult?> FirstOrDefaultAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    where TQuery : class
    where TResult : class;
  Task<IEnumerable<TResult>> ListAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    where TQuery : class
    where TResult : class;
  Task<int> CountAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    where TQuery : class
    where TResult : class;
  Task<bool> AnyAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    where TQuery : class
    where TResult : class;
}
