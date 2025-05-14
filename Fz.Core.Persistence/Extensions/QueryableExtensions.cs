using Microsoft.EntityFrameworkCore;

namespace Fz.Core.Persistence.Extensions;
public static class QueryableExtensions
{
  public static IQueryable<T> IncludeDeleted<T>(this IQueryable<T> query) where T : class
    => query.IgnoreQueryFilters();
}
