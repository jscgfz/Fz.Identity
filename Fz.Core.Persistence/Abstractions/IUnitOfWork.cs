using Microsoft.EntityFrameworkCore.Storage;

namespace Fz.Core.Persistence.Abstractions;

public interface IUnitOfWork
{
  int SaveChanges();
  int SaveChanges(bool acceptAllChangesOnSuccess);
  Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
}
