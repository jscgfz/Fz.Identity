namespace Fz.Core.Persistence.Abstractions;

public interface ISpecification<TQuery, TResult>
  where TQuery : class
  where TResult : class
{
  IQueryable<TResult> Apply(IQueryable<TQuery> query);
}