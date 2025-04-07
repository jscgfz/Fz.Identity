using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fz.Core.Result.Extensions;

public static class ResultExtensions
{
  public static Result<TOut> Map<TIn, TOut>(
    this Result<TIn> result,
    Func<TIn, TOut> func
  ) => result.IsSuccess ? Result.Success(func(result.Value)) : Result.Failure<TOut>(result.Type, result.Errors);

  public static async Task<Result<TOut>> Map<TIn, TOut>(
    this Task<Result<TIn>> result,
    Func<TIn, TOut> func
  ) => Map(await result, func);

  public static async Task<Result<TOut>> Map<TIn, TOut>(
    this Task<Result<TIn>> result,
    Func<TIn, Task<Result<TOut>>> func
  )
  {
    Result<TIn> result1 = await result;
    return result1.IsSuccess ? await func(result1.Value) : Result.Failure<TOut>(result1.Type, result1.Errors);
  }

  public static IResult Problem(this Result result)
   => Results.Problem(result.ProblemDetails());

  public static ProblemDetails ProblemDetails(this Result result)
    => result.IsSuccess
      ? throw new InvalidOperationException("No se puede crear un problema a partir de un resultado exitoso")
      : new ProblemDetails
      {
        Status = result.Type.Status,
        Type = result.Type.Type,
        Title = result.Type.Title,
        Extensions = new Dictionary<string, object?>()
        {
          ["errors"] = result.Errors.GroupBy(e => e.Code!).ToDictionary(g => g.Key, g => g.Select(e => e.Description))
        }
      };

  public static IResult ToResult(this Result result)
  {
    if (result.IsSuccess)
      return Results.Ok();

    return result.Problem();
  }

  public static async Task<IResult> ToResult(this Task<Result> result)
    => (await result).ToResult();

  public static IResult ToResult<T>(this Result<T> result)
  {
    if (result.IsSuccess)
      return Results.Ok(result.Value);
    return result.Problem();
  }

  public static async Task<IResult> ToResult<T>(this Task<Result<T>> result)
    => (await result).ToResult();
}
