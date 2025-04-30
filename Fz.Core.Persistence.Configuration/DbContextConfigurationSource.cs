using Fz.Core.Persistence.Configuration.Abstractions;
using Fz.Core.Persistence.Configuration.Providers;
using Microsoft.Extensions.Configuration;

namespace Fz.Core.Persistence.Configuration;

internal sealed class DbContextConfigurationSource<TContext, TUser> : IConfigurationSource
  where TContext : DatabaseContext
  where TUser : IEquatable<TUser>
{
  private readonly IServiceProvider _provider;
  public IContextConfigurationSourceWatcher? Watcher;

  public DbContextConfigurationSource(IServiceProvider provider)
    => _provider = provider;

  public DbContextConfigurationSource(IServiceProvider provider, IContextConfigurationSourceWatcher watcher) : this(provider)
    => Watcher = watcher;

  public IConfigurationProvider Build(IConfigurationBuilder builder)
    => new DbContextConfigurationProvider<TContext, TUser>(_provider, this);
}

internal sealed class DbContextConfigurationSource<TContext> : IConfigurationSource
  where TContext : DatabaseContext
{
  private readonly IServiceProvider _provider;
  public IContextConfigurationSourceWatcher? Watcher;

  public DbContextConfigurationSource(IServiceProvider provider)
    => _provider = provider;

  public DbContextConfigurationSource(IServiceProvider provider, IContextConfigurationSourceWatcher watcher) : this(provider)
    => Watcher = watcher;

  public IConfigurationProvider Build(IConfigurationBuilder builder)
    => new DbContextConfigurationProvider<TContext>(_provider, this);
}