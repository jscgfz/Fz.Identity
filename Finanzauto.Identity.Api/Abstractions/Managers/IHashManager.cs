using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using MediatR;

namespace Finanzauto.Identity.Api.Abstractions.Managers;

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
  /// <summary>
  /// Generates a password with the applicationConfiguration
  /// </summary>
  string NewPassword();
}
