using Fz.Core.Domain.Primitives.Abstractions;
using Fz.Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Fz.Core.Persistence.Conventions;

public sealed class BaseEntityConvention : IModelFinalizingConvention
{
  public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    => modelBuilder
      .Metadata
      .GetEntityTypes()
      .Where(entityType => entityType.ClrType is { IsAbstract: false, IsInterface: false } && typeof(IBaseEntity<>).IsAssignableFrom(entityType.ClrType))
      .Select(entityType => entityType.FindProperty(nameof(IBaseEntity<Guid>.Id)) ?? throw new NullReferenceException())
      .ToList()
      .ForEach(conventionProp =>
      {
        conventionProp.SetValueGenerated(ValueGenerated.OnAddOrUpdate);
        string? asignation = conventionProp.ClrType switch
        {
          Type t when t == typeof(Guid) => conventionProp.SetDefaultValueSql(DatabaseDefaultValues.Guid),
          Type t when t == typeof(int) => string.Empty,
          _ => throw new NotImplementedException()
        };
      });
}
