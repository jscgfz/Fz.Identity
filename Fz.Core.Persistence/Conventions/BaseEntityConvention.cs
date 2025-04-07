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
      .Where(entityType => entityType.ClrType is { IsAbstract: false, IsInterface: false } && entityType.ClrType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseEntity<>)))
      .Select(entityType => entityType.FindProperty(nameof(IBaseEntity<Guid>.Id)) ?? throw new NullReferenceException())
      .ToList()
      .ForEach(conventionProp =>
      {
        string? asignation = conventionProp.ClrType switch
        {
          Type t when t == typeof(Guid) => ApplyGuid(conventionProp),
          Type t when t == typeof(int) => string.Empty,
          _ => throw new NotImplementedException()
        };
      });

  private static string? ApplyGuid(IConventionProperty conventionProp)
  {
    conventionProp.SetValueGenerated(ValueGenerated.OnAddOrUpdate);
    return conventionProp.SetDefaultValueSql(DatabaseDefaultValues.Guid);
  }
}
