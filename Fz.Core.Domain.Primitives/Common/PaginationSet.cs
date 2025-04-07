using Fz.Core.Domain.Primitives.Abstractions.Common;

namespace Fz.Core.Domain.Primitives.Common;

public sealed class PaginationSet<TResult>(IEnumerable<TResult> data, int pageCount, int pageIndex, int pageSize) : IPaginatedResult<TResult>
  where TResult : class
{
  public int Count => Data.Count();
  public IEnumerable<TResult> Data { get; private set; } = data;
  public int PageCount { get; private set; } = pageCount;
  public int PageIndex { get; private set; } = pageIndex;
  public int PageSize { get; private set; } = pageSize;
}
