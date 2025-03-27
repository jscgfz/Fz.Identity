using Fz.Core.Domain.Primitives.Abstractions;
using Fz.Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Fz.Core.Persistence.Interceptors;

public sealed class AuditableEntityInterceptor<TContext, TUser>(IContextControlFieldsManager<TUser> contextControlFieldsManager) : SaveChangesInterceptor, ISaveChangesInterceptor
  where TContext : DatabaseContext, new()
  where TUser : IEquatable<TUser>
{
  private readonly IContextControlFieldsManager<TUser> _contextControlFieldsManager = contextControlFieldsManager;

  public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
  {
    SetControlFields(eventData);
    return base.SavingChanges(eventData, result);
  }

  public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
  {
    SetControlFields(eventData);
    return base.SavingChangesAsync(eventData, result, cancellationToken);
  }

  private void SetControlFields(DbContextEventData eventData)
  {
    if (eventData.Context is TContext context)
      foreach (EntityEntry entry in context.ChangeTracker.Entries())
        if (typeof(IAuditableEntity<TUser>).IsAssignableFrom(entry.Metadata.ClrType))
          if (entry.State == EntityState.Modified)
          {
            entry.Property(nameof(IAuditableEntity<TUser>.ModifiedAtUtc)).CurrentValue = _contextControlFieldsManager.UtcNow;
            entry.Property(nameof(IAuditableEntity<TUser>.ModifiedBy)).CurrentValue = _contextControlFieldsManager.CurrentUserId;
          }
          else if (entry.State == EntityState.Added)
          {
            entry.Property(nameof(IAuditableEntity<TUser>.CreatedAtUtc)).CurrentValue = _contextControlFieldsManager.UtcNow;
            entry.Property(nameof(IAuditableEntity<TUser>.CreatedBy)).CurrentValue = _contextControlFieldsManager.CurrentUserId;
          }
  }
}
