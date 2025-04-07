using System.Diagnostics.CodeAnalysis;

namespace Fz.Core.Cache.Abstractions;

public interface ICacheManager : ICancellableCacheManager
{
  Task<string?> TryGetStringAsync(string key);
  Task<string> GetOrSetStringAsync(string key, Func<Task<string>> func);
  Task<string> GetOrSetStringAsync(string key, Func<Task<string>> func, TimeSpan expiration);
  Task SetStringAsync(string key, string value);
  Task SetStringAsync(string key, string value, TimeSpan expiration);
  Task Set<TValue>(string key, TValue value);
  Task Set<TValue>(string key, TValue value, TimeSpan expiration);
  Task<TResult?> TryGetAsync<TResult>(string key);
  Task<TResult> GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func);
  Task<TResult> GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, TimeSpan expiration);
  Task RemoveAsync(string key);
  IAsyncEnumerable<string> KeysAsync();
  IAsyncEnumerable<string> KeysAsync([StringSyntax(StringSyntaxAttribute.Regex)] string pattern);
}
