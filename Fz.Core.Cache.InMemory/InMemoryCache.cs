using Fz.Core.Cache.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace Fz.Core.Cache.InMemory;

public sealed class InMemoryCache(IMemoryCache cache) : ICacheManager
{
  private readonly IMemoryCache _cache = cache;

  public Task Set<TValue>(string key, TValue value)
  {
    _cache.Set(key, value);
    return Task.CompletedTask;
  }

  public Task Set<TValue>(string key, TValue value, TimeSpan expiration)
  {
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, value, options);
    return Task.CompletedTask;
  }

  public Task Set<TValue>(string key, TValue value, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      Set(key, value);
    return Task.CompletedTask;
  }

  public Task Set<TValue>(string key, TValue value, TimeSpan expiration, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      Set(key, value, expiration);
    return Task.CompletedTask;
  }

  async Task<TResult> ICacheManager.GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func)
  {
    if (_cache.TryGetValue(key, out TResult? result))
      return result!;
    result = await func();
    _cache.Set(key, result);
    return result;
  }

  async Task<TResult> ICacheManager.GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, TimeSpan expiration)
  {
    if (_cache.TryGetValue(key, out TResult? result))
      return result!;
    result = await func();
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, result, options);
    return result;
  }

  async Task<TResult> ICancellableCacheManager.GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, CancellationToken cancellationToken)
  {
    if(cancellationToken.IsCancellationRequested)
      return default!;
    if (_cache.TryGetValue(key, out TResult? result))
      return result!;
    result = await func();
    _cache.Set(key, result);
    return result;
  }

  async Task<TResult> ICancellableCacheManager.GetOrSetAsync<TResult>(string key, Func<Task<TResult>> func, TimeSpan expiration, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      return default!;
    if (_cache.TryGetValue(key, out TResult? result))
      return result!;
    result = await func();
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, result, options);
    return result;
  }

  async Task<string> ICacheManager.GetOrSetStringAsync(string key, Func<Task<string>> func)
  {
    if (_cache.TryGetValue(key, out string? result))
      return result!;
    result = await func();
    _cache.Set(key, result);
    return result;
  }

  async Task<string> ICacheManager.GetOrSetStringAsync(string key, Func<Task<string>> func, TimeSpan expiration)
  {
    if (_cache.TryGetValue(key, out string? result))
      return result!;
    result = await func();
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, result, options);
    return result;
  }

  async Task<string> ICancellableCacheManager.GetOrSetStringAsync(string key, Func<Task<string>> func, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      return default!;
    if (_cache.TryGetValue(key, out string? result))
      return result!;
    result = await func();
    _cache.Set(key, result);
    return result;
  }

  async Task<string> ICancellableCacheManager.GetOrSetStringAsync(string key, Func<Task<string>> func, TimeSpan expiration, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      return default!;
    if (_cache.TryGetValue(key, out string? result))
      return result!;
    result = await func();
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, result, options);
    return result;
  }

  IAsyncEnumerable<string> ICacheManager.KeysAsync()
  {
    throw new NotImplementedException();
  }

  IAsyncEnumerable<string> ICacheManager.KeysAsync(string pattern)
  {
    throw new NotImplementedException();
  }

  Task ICacheManager.RemoveAsync(string key)
  {
    _cache.Remove(key);
    return Task.CompletedTask;
  }

  Task ICancellableCacheManager.RemoveAsync(string key, CancellationToken cancellationToken)
  {
    if (!cancellationToken.IsCancellationRequested)
      _cache.Remove(key);
    return Task.CompletedTask;
  }

  Task ICacheManager.SetStringAsync(string key, string value)
  {
    _cache.Set(key, value);
    return Task.CompletedTask;
  }

  Task ICacheManager.SetStringAsync(string key, string value, TimeSpan expiration)
  {
    MemoryCacheEntryOptions options = new()
    {
      AbsoluteExpirationRelativeToNow = expiration,
    };
    _cache.Set(key, value, options);
    return Task.CompletedTask;
  }

  Task ICancellableCacheManager.SetStringAsync(string key, string value, CancellationToken cancellationToken)
  {
    if (!cancellationToken.IsCancellationRequested)
      _cache.Set(key, value);
    return Task.CompletedTask;
  }

  Task ICancellableCacheManager.SetStringAsync(string key, string value, TimeSpan expiration, CancellationToken cancellationToken)
  {
    if (!cancellationToken.IsCancellationRequested)
    {
      MemoryCacheEntryOptions options = new()
      {
        AbsoluteExpirationRelativeToNow = expiration,
      };
      _cache.Set(key, value, options);
    }
    return Task.CompletedTask;
  }

  Task<TResult?> ICacheManager.TryGetAsync<TResult>(string key) where TResult : default
    => Task.FromResult(_cache.Get<TResult>(key));

  Task<TResult?> ICancellableCacheManager.TryGetAsync<TResult>(string key, CancellationToken cancellationToken) where TResult : default
  {
    if (!cancellationToken.IsCancellationRequested)
      return Task.FromResult(_cache.Get<TResult>(key));
    return Task.FromResult(default(TResult));
  }

  Task<string?> ICacheManager.TryGetStringAsync(string key)
    => Task.FromResult(_cache.Get<string>(key));

  Task<string?> ICancellableCacheManager.TryGetStringAsync(string key, CancellationToken cancellationToken)
  {
    if (!cancellationToken.IsCancellationRequested)
      return Task.FromResult(_cache.Get<string>(key));
    return Task.FromResult(default(string));
  }
}
