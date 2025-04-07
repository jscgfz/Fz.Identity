using Fz.Core.Domain.Primitives.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;

namespace Fz.Core.Persistence.Conventions;

public sealed class SoftDeleteableEntityConvention : IModelFinalizingConvention
{
  public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    => modelBuilder
      .Metadata
      .GetEntityTypes()
      .Where(entityType => entityType.ClrType is { IsAbstract: false, IsInterface: false } && entityType.ClrType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISoftDeleteableEntity<>)))
      .ToList()
      .ForEach(entityType =>
      {
        ParameterExpression param = Expression.Parameter(entityType.ClrType, "row");
        MemberExpression prop = Expression.PropertyOrField(param, nameof(ISoftDeleteableEntity<Guid>.IsDeleted));
        LambdaExpression exp = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);
        entityType.SetQueryFilter(exp);
        IConventionProperty state = entityType.FindProperty(nameof(ISoftDeleteableEntity<Guid>.IsDeleted)) ?? throw new NullReferenceException();
        state.SetDefaultValue(false);
      });
}
