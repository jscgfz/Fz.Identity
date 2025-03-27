namespace Fz.Core.Cache.Abstractions;

public interface ICancellableCacheManager
{
  Task<string?> TryGetStringAsync(string key, CancellationToken cancellationToken);
  Task<string> GetOrSetStringAsync(string key, Func<Task<string>> func, CancellationToken cancellationToken);
  Task<string> GetOrSetStringAsync(string key, Func<Task<string>> func, TimeSpan expiration, CancellationToken cancellationToken);
  Task SetStringAsync(string key, string value, CancellationToken cancellationToken);
  Task SetStringAsync(string key, string value, TimeSpan expiration, CancellationToken cancellationToken);
  Task<TResult?> TryGetAsync<TResult>(string key, CancellationToken cancellationToken);
  Task<TResult> GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, CancellationToken cancellationToken);
  Task<TResult> GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, TimeSpan expiration, CancellationToken cancellationToken);
  Task RemoveAsync(string key, CancellationToken cancellationToken);
}
