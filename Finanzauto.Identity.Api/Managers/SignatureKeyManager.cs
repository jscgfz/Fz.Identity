using Finanzauto.Identity.Api.Abstractions.Managers;
using System.Text;

namespace Finanzauto.Identity.Api.Managers;

/// <inheritdoc/>
public sealed class SignatureKeyManager : ISignatureKeyManager
{
  /// <inheritdoc/>
  public Encoding Encoding =>
    Encoding.UTF8;
  /// <inheritdoc/>
  public byte[] FromString(string data)
    => Convert.FromBase64String(data);
  /// <inheritdoc/>
  public byte[] New() =>
    System.Security.Cryptography.RandomNumberGenerator.GetBytes(32);

  public string NewHexString()
    => Convert.ToHexString(New());

  /// <inheritdoc/>
  public string NewString()
    => Convert.ToBase64String(New()); 
}
