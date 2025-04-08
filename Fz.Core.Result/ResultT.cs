using Fz.Core.Result.Common;

namespace Fz.Core.Result;

public sealed class Result<TValue>(
  ResultType type, TValue? value, IEnumerable<Error>? errors = default) : Result(type, errors)
{
  private readonly TValue? _value = value;
  public TValue Value
  {
    get
    {
      Guards.Not(() => IsSuccess, new InvalidOperationException("No hay valores para un resultado erroneo"));
      Guards.ThrowIfNull(_value, nameof(Value));
      return _value!;
    }
  }

  public static implicit operator Result<TValue>(TValue? value)
    => From(value!, ResultTypes.NotFound, [new Error("Object.NotFound", "Elemento no encontrado")]);
}
