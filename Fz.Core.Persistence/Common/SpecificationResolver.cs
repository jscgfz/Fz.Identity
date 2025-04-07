using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Domain.Primitives.Common;
using Fz.Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Fz.Core.Persistence.Common;

public sealed class SpecificationResolver
{
  public static async Task<IPaginatedResult<TResult>> Compute<TQuery, TResult, TParams>(
    Func<TParams, ISpecification<TQuery, TResult>> func,
    TParams parameters,
    IReadOnlyDbContext context
  )
    where TParams : IPaginationParams
    where TQuery : class
    where TResult : class
  {
    ISpecification<TQuery, TResult> spec = func(parameters);
    IQueryable<TResult> query = spec.Apply(context.Repository<TQuery>());
    int count = await context.Repository<TQuery>().CountAsync();
    int pageCount = (int)Math.Ceiling((double)count / (parameters.PageSize ?? 10));
    IEnumerable<TResult> data = await query
      .Skip((parameters.PageIndex ?? 1) * ((parameters.Page ?? 1) - 1))
      .Take(parameters.PageSize ?? 10)
      .ToListAsync();
    
    return new PaginationSet<TResult>(data, pageCount, parameters.Page ?? 1, parameters.PageSize ?? 10);
  }

  public static async Task<Result.Result<IPaginatedResult<TResult>>> ComputeResult<TQuery, TResult, TParams>(
    Func<TParams, ISpecification<TQuery, TResult>> func,
    TParams parameters,
    IReadOnlyDbContext context,
    IEnumerable<Result.Error> errors
  )
    where TParams : IPaginationParams
    where TQuery : class
    where TResult : class
  {
    IPaginatedResult<TResult> result = await Compute(func, parameters, context);
    return result.Data.Any() ? Result.Result.Success(result) : Result.Result.Failure<IPaginatedResult<TResult>>(Result.ResultTypes.NotFound, errors);
  }
}
