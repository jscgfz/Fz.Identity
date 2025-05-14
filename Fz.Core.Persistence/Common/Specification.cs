using Fz.Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Fz.Core.Domain.Primitives.Abstractions.Common;

namespace Fz.Core.Persistence.Common;

public class Specification<TQuery, TResult> : ISpecification<TQuery, TResult>
  where TQuery : class
  where TResult : class
{
  private Expression<Func<TQuery, bool>>? _predicate;
  private IEnumerable<Expression<Func<TQuery, object>>> _expressionNavigations = [];
  private IEnumerable<string> _strNavigations = [];
  private Expression<Func<TQuery, object>>? _orderBy;
  private Expression<Func<TQuery, object>>? _orderByDesc;
  private Expression<Func<TQuery, object>>? _thenOrderBy;
  private Action<IQueryable<TQuery>>? _action;
  private Expression<Func<TQuery, TResult>>? _cast;
  private int? _take;
  private int? _skip;
  private bool _includeDeleted = false;

  public Specification() { }

  public Specification<TQuery, TResult> From(Action<IQueryable<TQuery>> action)
  {
    _action = action;
    return this;
  }

  public Specification<TQuery, TResult> WithSelect(Expression<Func<TQuery, TResult>> selector)
  {
    _cast = selector;
    return this;
  }

  public Specification<TQuery, TResult> WithFilter(Expression<Func<TQuery, bool>> predicate)
  {
    _predicate = predicate;
    return this;
  }

  public Specification<TQuery, TResult> WithAndFilter(Expression<Func<TQuery, bool>> predicate)
  {
    if (_predicate is null)
      return WithFilter(predicate);

    ParameterExpression parameter = Expression.Parameter(typeof(TQuery), "row");
    InvocationExpression mainPredicate = Expression.Invoke(_predicate, parameter);
    InvocationExpression nestedPredicate = Expression.Invoke(predicate, parameter);
    _predicate = Expression.Lambda<Func<TQuery, bool>>(Expression.And(mainPredicate, nestedPredicate), parameter);
    return this;
  }

  public Specification<TQuery, TResult> WithAndAlsoFilter(Expression<Func<TQuery, bool>> predicate)
  {
    if (_predicate is null)
      return WithFilter(predicate);

    ParameterExpression parameter = Expression.Parameter(typeof(TQuery), "row");
    InvocationExpression mainPredicate = Expression.Invoke(_predicate, parameter);
    InvocationExpression nestedPredicate = Expression.Invoke(predicate, parameter);
    _predicate = Expression.Lambda<Func<TQuery, bool>>(Expression.AndAlso(mainPredicate, nestedPredicate), parameter);
    return this;
  }

  public Specification<TQuery, TResult> WithOrFilter(Expression<Func<TQuery, bool>> predicate)
  {
    if (_predicate is null)
      return WithFilter(predicate);

    ParameterExpression parameter = Expression.Parameter(typeof(TQuery), "row");
    InvocationExpression mainPredicate = Expression.Invoke(_predicate, parameter);
    InvocationExpression nestedPredicate = Expression.Invoke(predicate, parameter);
    _predicate = Expression.Lambda<Func<TQuery, bool>>(Expression.Or(mainPredicate, nestedPredicate), parameter);
    return this;
  }

  public Specification<TQuery, TResult> WithExclusiveOrFilter(Expression<Func<TQuery, bool>> predicate)
  {
    if (_predicate is null)
      return WithFilter(predicate);

    ParameterExpression parameter = Expression.Parameter(typeof(TQuery), "row");
    InvocationExpression mainPredicate = Expression.Invoke(_predicate, parameter);
    InvocationExpression nestedPredicate = Expression.Invoke(predicate, parameter);
    _predicate = Expression.Lambda<Func<TQuery, bool>>(Expression.ExclusiveOr(mainPredicate, nestedPredicate), parameter);
    return this;
  }

  public Specification<TQuery, TResult> WithInclude(params Expression<Func<TQuery, object>>[] navigations)
  {
    _expressionNavigations = [.. _expressionNavigations, .. navigations];
    return this;
  }

  public Specification<TQuery, TResult> WithInclude(params string[] navigations)
  {
    _strNavigations = [.. _strNavigations, .. navigations];
    return this;
  }

  public Specification<TQuery, TResult> WithOrderBy(Expression<Func<TQuery, object>> orderBy)
  {
    _orderBy = orderBy;
    return this;
  }

  public Specification<TQuery, TResult> WithPagination(IPaginationParams pagination)
  {
    _take = pagination.PageSize;
    _skip = pagination.PageIndex * pagination.PageSize;
    return this;
  }

  public Specification<TQuery, TResult> WithOrderByDesc(Expression<Func<TQuery, object>> orderByDesc)
  {
    _orderByDesc = orderByDesc;
    return this;
  }

  public Specification<TQuery, TResult> WithThenOrderBy(Expression<Func<TQuery, object>> thenOrderBy)
  {
    if (_orderBy is null || _orderByDesc is null)
      throw new InvalidOperationException("OrderBy or OrderByDesc must be set before ThenOrderBy");
    _thenOrderBy = thenOrderBy;
    return this;
  }

  public Specification<TQuery, TResult> WithTake(int take)
  {
    _take = take;
    return this;
  }

  public Specification<TQuery, TResult> WithSkip(int skip)
  {
    _skip = skip;
    return this;
  }

  public Specification<TQuery, TResult> WithDeleted()
  {
    _includeDeleted = true;
    return this;
  }

  public virtual IQueryable<TResult> Apply(IQueryable<TQuery> query)
  {
    if (_action is not null)
      _action(query);
    if (_predicate is not null)
      query = query.Where(_predicate);
    foreach (Expression<Func<TQuery, object>> navigation in _expressionNavigations)
      query = query.Include(navigation);
    foreach (string navigation in _strNavigations)
      query = query.Include(navigation);
    if (_orderBy is not null)
      query = query.OrderBy(_orderBy);
    if (_orderByDesc is not null)
      query = query.OrderByDescending(_orderByDesc);
    if (_thenOrderBy is not null)
      if (_orderByDesc is not null)
        query = ((IOrderedQueryable<TQuery>)query).ThenByDescending(_thenOrderBy);
      else
        query = ((IOrderedQueryable<TQuery>)query).ThenBy(_thenOrderBy);
    if (_take.HasValue && _take.Value != 0)
      query = query.Take(_take.Value);
    if (_skip.HasValue && _skip.Value != 0)
      query = query.Skip(_skip.Value);
    if(_includeDeleted)
      query = query.IgnoreQueryFilters();
    return typeof(TResult) == typeof(TQuery) ? (IQueryable<TResult>)query : query.Select(_cast ?? throw new InvalidOperationException("Selector must be setted"));
  }
}

public class Specification<TQuery> : Specification<TQuery, TQuery>
  where TQuery : class
{
  public Specification() { }
}