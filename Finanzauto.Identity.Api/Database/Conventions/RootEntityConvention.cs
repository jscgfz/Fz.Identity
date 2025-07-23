using Finanzauto.Identity.Api.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Finanzauto.Identity.Api.Database.Conventions;

public sealed class RootEntityConvention : IModelFinalizingConvention
{
  public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
  {
    foreach(IConventionProperty conventionProp in modelBuilder.Metadata.GetEntityTypes()
      .Where(IsRootEntity)
      .Select(GetRoot))
    {
      conventionProp.SetDefaultValue(false);
    }
  }

  private static bool IsRootEntity(IConventionEntityType entityType)
    => entityType.ClrType is { IsAbstract: false, IsInterface: false } &&
    entityType.ClrType.GetInterfaces().Any(i => i == typeof(IRootEntity));

  private static IConventionProperty GetRoot(IConventionEntityType entityType)
    => entityType.FindProperty(nameof(IRootEntity.IsRoot)) ?? throw new NullReferenceException();
}
