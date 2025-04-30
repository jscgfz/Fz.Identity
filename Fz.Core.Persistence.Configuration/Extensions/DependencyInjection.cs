using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fz.Core.Persistence.Configuration.Extensions;

public static class DependencyInjection
{
  public static WebApplicationBuilder WithConfigurationFromContext<TContext, TUser>(this WebApplicationBuilder builder)
    where TContext : DatabaseContext
    where TUser : IEquatable<TUser>
  {
    IServiceProvider provider = builder.Services.BuildServiceProvider();
    IConfigurationBuilder configurationBuilder = builder.Configuration;
    configurationBuilder.Add(new DbContextConfigurationSource<TContext, TUser>(provider));
    return builder;
  }

  public static WebApplicationBuilder WithConfigurationFromContext<TContext>(this WebApplicationBuilder builder)
    where TContext : DatabaseContext
  {
    IServiceProvider provider = builder.Services.BuildServiceProvider();
    IConfigurationBuilder configurationBuilder = builder.Configuration;
    configurationBuilder.Add(new DbContextConfigurationSource<TContext>(provider));
    return builder;
  }

  public static WebApplicationBuilder WithConfigurationFromContext<TContext, TUser>(this WebApplicationBuilder builder, TimeSpan reloadInterval)
    where TContext : DatabaseContext
    where TUser : IEquatable<TUser>
  {
    IServiceProvider provider = builder.Services.BuildServiceProvider();
    IConfigurationBuilder configurationBuilder = builder.Configuration;
    configurationBuilder.Add(new DbContextConfigurationSource<TContext, TUser>(provider, new DbContextPeriodicalWatcher(reloadInterval)));
    return builder;
  }

  public static WebApplicationBuilder WithConfigurationFromContext<TContext>(this WebApplicationBuilder builder, TimeSpan reloadInterval)
    where TContext : DatabaseContext
  {
    IServiceProvider provider = builder.Services.BuildServiceProvider();
    IConfigurationBuilder configurationBuilder = builder.Configuration;
    configurationBuilder.Add(new DbContextConfigurationSource<TContext>(provider, new DbContextPeriodicalWatcher(reloadInterval)));
    return builder;
  }
}
