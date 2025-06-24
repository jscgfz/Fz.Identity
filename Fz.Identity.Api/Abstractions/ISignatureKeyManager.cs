using System.Text;

namespace Fz.Identity.Api.Abstractions;

/// <summary>
/// Interface for managing cryptographic signature keys.
/// </summary>
public interface ISignatureKeyManager
{
  /// <summary>
  /// Generates a new cryptographic signature key.
  /// </summary>
  byte[] New();
  /// <summary>
  /// Gets the current cryptographic signature key encofing factory.
  /// </summary>
  Encoding Encoding { get; }
  /// <summary>
  /// Generates a new string cryptographic signature key representation.
  /// </summary>
  string NewString();
  /// <summary>
  /// Generates a new cryptographic signature key from string value.
  /// </summary>
  /// <param name="data"></param>
  byte[] FromString(string data);
}
