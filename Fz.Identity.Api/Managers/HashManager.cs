using Fz.Core.Result;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Models.Identity;
using MediatR;

namespace Fz.Identity.Api.Managers;

/// <inheritdoc/>
public sealed class HashManager(IServiceProvider provider) : IHashManager
{
  private readonly ISignatureKeyManager _key = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IConfiguration _config = provider.GetRequiredService<IConfiguration>();

  /// <inheritdoc/>
  public Task<Result<HashResponse>> ComputeHash(string data, CancellationToken cancellationToken)
  => Task.Run(() =>
  {
    byte[] salt = _key.New();
    byte[] byteData = _key.Encoding.GetBytes(data);
    using var hmac = new System.Security.Cryptography.HMACSHA256(salt);
    byte[] hash = hmac.ComputeHash(byteData);
    return Result.Success(
      new HashResponse(data, hash, salt)
    );
  }, cancellationToken);


  /// <inheritdoc/>
  public Task<Result<Unit>> ValidateHash(HashRequest resuest, CancellationToken cancellationToken, params IEnumerable<Error> onError)
   => Task.Run(() =>
   {
     using var hmac = new System.Security.Cryptography.HMACSHA256(resuest.Salt);
     byte[] byteData = _key.Encoding.GetBytes(resuest.Data);
     byte[] computedHash = hmac.ComputeHash(byteData);
     bool isValid = computedHash.SequenceEqual(resuest.Hash);
     return isValid
       ? Result.Success(new Unit())
       : Result.Failure<Unit>(
          ResultTypes.ValidationError,
          onError
         );
   }, cancellationToken);
}
