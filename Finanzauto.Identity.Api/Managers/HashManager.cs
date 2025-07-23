using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Common;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using Finanzauto.Identity.Api.Models.Settings.Security;
using MediatR;

namespace Finanzauto.Identity.Api.Managers;

/// <inheritdoc/>
public sealed class HashManager(IServiceProvider provider) : IHashManager
{
  private readonly ISignatureKeyManager _key = provider.GetRequiredService<ISignatureKeyManager>();
  private readonly IAppConfigurationManager _config = provider.GetRequiredService<IAppConfigurationManager>();
  private PasswordGenerationSettings _settings => _config.Get<PasswordGenerationSettings>()!;

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

  public string NewPassword()
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc/>
  public Task<Result<Unit>> ValidateHash(HashRequest resuest, CancellationToken cancellationToken, params IEnumerable<Error> onError)
   => Task.Run(() =>
   {
     using var hmac = new System.Security.Cryptography.HMACSHA256(resuest.Salt);
     byte[] byteData = _key.Encoding.GetBytes(resuest.Data);
     byte[] computedHash = hmac.ComputeHash(byteData);
     bool isValid = computedHash.SequenceEqual(resuest.Hash);
     return isValid
       ? Result.Success(Result.Unit)
       : Result.Failure<Unit>(
          ResultTypes.ValidationError,
          onError
         );
   }, cancellationToken);
}
