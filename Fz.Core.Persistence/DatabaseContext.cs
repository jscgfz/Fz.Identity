using Fz.Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Fz.Core.Persistence;

public class DatabaseContext : DbContext, IDbContext, IUnitOfWork
{
  public DatabaseContext() : base() { }
  public DatabaseContext(DbContextOptions options) : base(options) { }

  void IDbContext.Add<TQuery>(TQuery entity)
    => Entry(entity).State = EntityState.Added;

  void IDbContext.AddRange<TQuery>(IEnumerable<TQuery> entities)
    => Set<TQuery>().AddRange(entities);

  Task<bool> IReadOnlyDbContext.AnyAsync<TQuery>(Expression<Func<TQuery, bool>> predicate)
    => Set<TQuery>().AnyAsync(predicate);

  Task<bool> IDbSpecificationContext.AnyAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    => spec.Apply(Set<TQuery>()).AnyAsync();

  Task<IDbContextTransaction> IUnitOfWork.BeginTransaction(CancellationToken cancellationToken)
    => Database.BeginTransactionAsync(cancellationToken);

  Task<int> IReadOnlyDbContext.CountAsync<TQuery>(Expression<Func<TQuery, bool>> predicate)
    => Set<TQuery>().CountAsync(predicate);

  Task<int> IDbSpecificationContext.CountAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    => spec.Apply(Set<TQuery>()).CountAsync();

  void IDbContext.Delete<TQuery>(TQuery entity)
    => Entry(entity).State = EntityState.Deleted;

  void IDbContext.DeleteRange<TQuery>(IEnumerable<TQuery> entities)
    => Set<TQuery>().RemoveRange(entities);

  ValueTask<TQuery?> IReadOnlyDbContext.FindByIdAsync<TQuery>(params object[] keys) where TQuery : class
    => FindAsync<TQuery>(keys);

  Task<TQuery?> IReadOnlyDbContext.FirstOrDefaultAsync<TQuery>(Expression<Func<TQuery, bool>> predicate) where TQuery : class
    => Set<TQuery>().FirstOrDefaultAsync(predicate);

  Task<TResult?> IDbSpecificationContext.FirstOrDefaultAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec) where TResult : class
    => spec.Apply(Set<TQuery>()).FirstOrDefaultAsync();

  async Task<IEnumerable<TQuery>> IReadOnlyDbContext.ListAsync<TQuery>(Expression<Func<TQuery, bool>> predicate)
    => await Set<TQuery>().Where(predicate).ToListAsync();

  async Task<IEnumerable<TResult>> IDbSpecificationContext.ListAsync<TQuery, TResult>(ISpecification<TQuery, TResult> spec)
    => await spec.Apply(Set<TQuery>()).ToListAsync();

  IQueryable<TQuery> IReadOnlyDbContext.Repository<TQuery>()
    => Set<TQuery>();

  void IDbContext.Update<TQuery>(TQuery entity)
    => Entry(entity).State = EntityState.Modified;

  void IDbContext.UpdateRange<TQuery>(IEnumerable<TQuery> entities)
    => Set<TQuery>().UpdateRange(entities);
}
