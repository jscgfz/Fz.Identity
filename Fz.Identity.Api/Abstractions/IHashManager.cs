using Fz.Core.Result;
using Fz.Identity.Api.Models.Identity;
using MediatR;

namespace Fz.Identity.Api.Abstractions;

/// <summary>
/// Interface for managing hash computations and validations.
/// </summary>
public interface IHashManager
{
  /// <summary>
  /// Computes a hash for the given data asynchronously.
  /// </summary>
  /// <param name="data">data to hash</param>
  /// <param name="cancellationToken">cancellation token</param>
  Task<Result<HashResponse>> ComputeHash(string data, CancellationToken cancellationToken);
  /// <summary>
  /// Validates a hash against the provided data asynchronously.
  /// </summary>
  /// <param name="resuest">has request</param>
  /// <param name="cancellationToken">cancellation token</param>
  /// <param name="onError">errors on failure</param>
  Task<Result<Unit>> ValidateHash(HashRequest resuest, CancellationToken cancellationToken, params IEnumerable<Error> onError);
}