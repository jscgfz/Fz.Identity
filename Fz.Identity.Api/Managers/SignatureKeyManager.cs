using Fz.Identity.Api.Abstractions;
using System.Text;

namespace Fz.Identity.Api.Managers;

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
  /// <inheritdoc/>
  public string NewString()
    => Convert.ToBase64String(New());
}
