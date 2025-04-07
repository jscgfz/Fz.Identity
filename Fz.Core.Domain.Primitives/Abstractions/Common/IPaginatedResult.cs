namespace Fz.Core.Domain.Primitives.Abstractions.Common;

public interface IPaginatedResult<TResult>
  where TResult : class
{
  int Count { get; }
  IEnumerable<TResult> Data { get; }
  int PageCount { get; }
  int PageIndex { get; }
  int PageSize { get; }
}
