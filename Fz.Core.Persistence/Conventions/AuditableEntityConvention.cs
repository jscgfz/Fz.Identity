using Fz.Core.Domain.Primitives.Abstractions;
using Fz.Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Fz.Core.Persistence.Conventions;

public sealed class AuditableEntityConvention : IModelFinalizingConvention
{
  public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    => modelBuilder
      .Metadata
      .GetEntityTypes()
      .Where(entityType => entityType.ClrType is { IsAbstract: false, IsInterface: false } && typeof(IAuditableEntity<>).IsAssignableFrom(entityType.ClrType))
      .ToList()
      .ForEach(entityType =>
      {
        IConventionProperty date = entityType.FindProperty(nameof(IAuditableEntity<Guid>.CreatedAtUtc)) ?? throw new NullReferenceException();
        IConventionProperty user = entityType.FindProperty(nameof(IAuditableEntity<Guid>.CreatedBy)) ?? throw new NullReferenceException();
        date.SetDefaultValueSql(DatabaseDefaultValues.UtcNow);
        object? asignation = user.ClrType switch
        {
          Type t when t == typeof(Guid) => user.SetDefaultValue(Guid.Empty),
          Type t when t == typeof(int) => user.SetDefaultValue(0),
          _ => throw new NotImplementedException()
        };
      });
}
