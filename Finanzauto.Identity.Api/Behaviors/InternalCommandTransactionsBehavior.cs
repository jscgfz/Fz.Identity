using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Finanzauto.Identity.Api.Behaviors;

public sealed class InternalCommandTransactionsBehavior<TRequest, TResponse>(IServiceProvider provider) : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull, IRequest<TResponse>
{
  private readonly IEnumerable<IUnitOfWork> _unitsOfWork = [
    ..provider.GetServices<IUnitOfWork>()
  ];
  private readonly IHttpContextAccessor _http =
  provider.GetRequiredService<IHttpContextAccessor>();

  /// <inheritdoc/>
  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    IEnumerable<IDbContextTransaction> transactions = await Task.WhenAll(
      _unitsOfWork.Select(u => u.BeginTransaction(cancellationToken))
    );

    try
    {
      TResponse response = await next(cancellationToken);
      Type responseType = typeof(TResponse);
      if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
      {
        PropertyInfo? prop = responseType.GetProperty(nameof(Result<int>.IsFailure));
        if (prop != null && (bool)prop.GetValue(response)!)
        {
          await Task.WhenAll(
          transactions.Select(t => t.RollbackAsync(cancellationToken))
        );
          return response;
        }

      }
      
      await Task.WhenAll(
        transactions.Select(t => t.CommitAsync(cancellationToken))
      );

      return response;
    }
    catch (Exception ex)
    {
      await Task.WhenAll(
        transactions.Select(t => t.RollbackAsync(cancellationToken))
      );

      IEnumerable<Error> errors = GetExceptionValues(ex)
        .Select(err => new Error("Internal.Error", err));

      ProblemDetails problemDetails = new()
      {
        Title = "500 - Unhandled Error",
        Status = StatusCodes.Status500InternalServerError,
        Detail = "Uno o más errores de validación han ocurrido",
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
        Instance = $"{_http.HttpContext?.Request.Method} - {_http.HttpContext?.Request.Path}",
        Extensions = errors
            .GroupBy(v => v.Code)
            .ToDictionary(
              static v => v.Key!,
              static v => (object?)v.Select(v => v.Description)
            )
      };

      Type responseType = typeof(TResponse);
      if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
        return (TResponse)Activator.CreateInstance(
          responseType,
          StatusCodes.Status500InternalServerError,
          null,
          errors
        )!;

      if (_http.HttpContext is not null)
      {
        _http.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        _http.HttpContext.Response.ContentType = "application/problem+json";
        await _http.HttpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
      }

      return default!;
    }
  }

  private static IEnumerable<string> GetExceptionValues<TException>(TException exception)
    where TException : Exception
  {
    yield return $"{exception.GetType().Name} - {exception.Message}";
    if (exception.InnerException is not null)
      foreach (string inner in GetExceptionValues(exception.InnerException))
        yield return inner;
  }
}