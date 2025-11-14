using System.Security.Cryptography;

namespace Fz.Identity.Api.Common.Security;

public static class EncryptionResolver
{
  public static string DecryptData(string message, byte[] key)
    => DecryptData(Convert.FromBase64String(message), key);

  public static string DecryptData(byte[] message, byte[] key)
  {
    using Aes aes = Aes.Create();
    aes.Key = key;
    aes.IV = key;
    aes.Mode = CipherMode.CBC;
    aes.Padding = PaddingMode.PKCS7;
    using ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV);
    using MemoryStream memo = new(message);
    using CryptoStream cs = new(memo, dec, CryptoStreamMode.Read);
    using StreamReader sr = new(cs);
    return sr.ReadToEnd();
  }

  public static string EncryptData(string message, byte[] key)
  {
    using Aes aes = Aes.Create();
    aes.Key = key;
    aes.IV = key;
    aes.Mode = CipherMode.CBC;
    aes.Padding = PaddingMode.PKCS7;
    using ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);
    using MemoryStream memo = new();
    using (CryptoStream cs = new(memo, enc, CryptoStreamMode.Write))
    using (StreamWriter sw = new(cs))
      sw.Write(message);

    return Convert.ToBase64String(memo.ToArray());
  }
}
