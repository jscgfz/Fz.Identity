using System.Linq.Expressions;

namespace Fz.Core.Result.Common;

public sealed class Guards
{
  public static void If(Expression<Func<bool>> predicate, Exception ex)
  {
    ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));
    if(predicate.Compile().Invoke()) throw ex;
  }
  public static void Not(Expression<Func<bool>> predicate, Exception ex)
  {
    ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));
    if (!predicate.Compile().Invoke()) throw ex;
  }

  public static void ThrowIfNull(object? argument, string? argumentName = null)
    => ArgumentNullException.ThrowIfNull(argument, argumentName);

  public static void ThrowIfNullOrEmpty(string? argument, string? argumentName = null)
    => ArgumentNullException.ThrowIfNullOrEmpty(argument, argumentName);

  public static void ThrowIfNullOrWhiteSpace(string? argument, string? argumentName = null)
    => ArgumentNullException.ThrowIfNullOrWhiteSpace(argument, argumentName);
}
