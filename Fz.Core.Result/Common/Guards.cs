using System.Linq.Expressions;

namespace Fz.Core.Result.Common;

public sealed class Guards
{
  public static void If<TException>(Expression<Func<bool>> predicate, TException ex)
    where TException : Exception
  {
    ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));
    if(predicate.Compile().Invoke()) throw ex;
  }
  public static void Not<TException>(Expression<Func<bool>> predicate, TException ex)
    where TException : Exception
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
