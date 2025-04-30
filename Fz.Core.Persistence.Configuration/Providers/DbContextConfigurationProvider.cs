using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace Fz.Core.Persistence.Configuration.Providers;

internal sealed class DbContextConfigurationProvider<TContext, TUser> : ConfigurationProvider, IDisposable
  where TContext : DatabaseContext
  where TUser : IEquatable<TUser>
{
  private readonly IServiceProvider _provider;
  private readonly DbContextConfigurationSource<TContext, TUser> _source;
  private readonly IDisposable? _registration;
  private bool _migrated = false;

  public DbContextConfigurationProvider(IServiceProvider provider, DbContextConfigurationSource<TContext, TUser> source)
  {
    _provider = provider;
    _source = source;

    if (_source.Watcher != null)
      _registration = ChangeToken.OnChange(
        () => _source.Watcher.Watch(),
        Load
      );
  }

  public void Dispose()
  {
    _registration?.Dispose();
  }

  public override void Load()
  {
    using IServiceScope scope = _provider.CreateScope();
    TContext _context = scope.ServiceProvider.GetRequiredService<TContext>();

    if (!_migrated)
    {
      _context.Database.Migrate();
      _migrated = !_migrated;
    }
    Data = _context
      .Set<DbConfigurationSection<TUser>>()
      .ToDictionary(
        static x => x.Id,
        static x => x.Value,
        StringComparer.OrdinalIgnoreCase
      );
  }
}

internal sealed class DbContextConfigurationProvider<TContext> : ConfigurationProvider
  where TContext : DatabaseContext
{
  private readonly IServiceProvider _provider;
  private readonly DbContextConfigurationSource<TContext> _source;
  private readonly IDisposable? _registration;
  private bool _migrated = false;

  public DbContextConfigurationProvider(IServiceProvider provider, DbContextConfigurationSource<TContext> source)
  {
    _provider = provider;
    _source = source;

    if (_source.Watcher != null)
      _registration = ChangeToken.OnChange(
        () => _source.Watcher.Watch(),
        Load
      );
  }

  public void Dispose()
  {
    _registration?.Dispose();
  }

  public override void Load()
  {
    using IServiceScope scope = _provider.CreateScope();
    TContext _context = scope.ServiceProvider.GetRequiredService<TContext>();
    if (!_migrated)
    {
      _context.Database.Migrate();
      _migrated = !_migrated;
    }
    Data = _context
      .Set<DbConfigurationSection>()
      .ToDictionary(
        static x => x.Id,
        static x => x.Value,
        StringComparer.OrdinalIgnoreCase
      );
  }
}
