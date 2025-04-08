using Fz.Core.Result.Common;
using System.Collections;

namespace Fz.Core.Result;

public class Result
{
  public ResultType Type { get; private set; }
  public IEnumerable<Error> Errors { get; private set; }
  public bool IsSuccess => ResultTypes.IsSuccess(Type);
  public bool IsFailure => !IsSuccess;

  protected internal Result(ResultType type, IEnumerable<Error>? errors = default)
  {
    Guards.ThrowIfNull(type, nameof(type));
    errors ??= [];
    Guards.Not(
      () => ResultTypes.IsValidType(type),
      new ArgumentException("Tipo de Resultado invalido", nameof(type)));
    Guards.If(
      () => !ResultTypes.IsSuccess(type) && (!errors.Any() || errors.Any(e => e == Error.Empty)),
      new ArgumentException("El resultado debe tener errores especificados", nameof(errors)));
    Guards.If(
      () => ResultTypes.IsSuccess(type) && (errors.Any(e => e != Error.Empty)),
      new ArgumentException("El resultado no debe tener errores especificados", nameof(errors)));
    (Type, Errors) = (type, errors);    
  }

  public static Result<TValue> From<TValue>(TValue? value, ResultType onErrorType, IEnumerable<Error> onError)
    => value is null || value is ICollection col && col.Count == 0 ? Failure<TValue>(onErrorType, onError) : Success(value);
  public static async Task<Result<TValue>> From<TValue>(Task<TValue?> promise, ResultType onErrorType, IEnumerable<Error> onError)
    => From(await promise, onErrorType, onError);
  public static Result Success() => new(ResultTypes.OK, [Error.Empty]);
  public static Result Success(ResultType type) => new(type, [Error.Empty]);
  public static Result<TValue> Success<TValue>(TValue value) => new(ResultTypes.OK, value, [Error.Empty]);
  public static Result<TValue> Success<TValue>(TValue value, ResultType type) => new(type, value, [Error.Empty]);
  public static Result ValidationError(IEnumerable<Error> errors) => new(ResultTypes.ValidationError, errors);
  public static Result<TValue> ValidationError<TValue>(IEnumerable<Error> errors) => new(ResultTypes.ValidationError, default, errors);
  public static Result UnhandledError(IEnumerable<Error> errors) => new(ResultTypes.UnhandledError, errors);
  public static Result<TValue> UnhandledError<TValue>(IEnumerable<Error> errors) => new(ResultTypes.UnhandledError, default, errors);
  public static Result Failure(ResultType type, IEnumerable<Error> errors) => new(type, errors);
  public static Result<TValue> Failure<TValue>(ResultType type, IEnumerable<Error> errors) => new(type, default, errors);
}
