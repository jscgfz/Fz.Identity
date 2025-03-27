using Fz.Core.Domain.Primitives.Abstractions;
using Fz.Core.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Fz.Core.Persistence.Interceptors;

public sealed class SoftDeleteableEntityInterceptor<TContext, TUser>(IContextControlFieldsManager<TUser> contextControlFieldsManager) : SaveChangesInterceptor, ISaveChangesInterceptor
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
        if (typeof(ISoftDeleteableEntity<TUser>).IsAssignableFrom(entry.Metadata.ClrType) && entry.State == EntityState.Deleted)
        {
          entry.State = EntityState.Modified;
          entry.Property(nameof(ISoftDeleteableEntity<TUser>.IsDeleted)).CurrentValue = true;
          entry.Property(nameof(ISoftDeleteableEntity<TUser>.DeletedAtUtc)).CurrentValue = _contextControlFieldsManager.UtcNow;
          entry.Property(nameof(ISoftDeleteableEntity<TUser>.DeletedBy)).CurrentValue = _contextControlFieldsManager.CurrentUserId;
          SetReferences(entry);
        }
  }

  private static void SetReferences(EntityEntry entry)
  {
    if (!entry.References.Any())
      return;
    foreach (ReferenceEntry reference in entry.References)
      if (reference.TargetEntry != null)
      {
        reference.TargetEntry.State = EntityState.Unchanged;
        SetReferences(reference.TargetEntry);
      }
  }
}
