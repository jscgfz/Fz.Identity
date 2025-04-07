using Fz.Core.Cache.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fz.Core.Cache.InMemory.Extensions;

public static class DependencyInjection
{
  public static WebApplicationBuilder WithInMemoryCache(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddMemoryCache();

    builder
      .Services
      .AddScoped<ICacheManager, InMemoryCache>();
    return builder;
  }

  public static WebApplicationBuilder WithKeyedInMemoryCache(this WebApplicationBuilder builder, object serviceKey)
  {
    builder
      .Services
      .AddMemoryCache();

    builder
      .Services
      .AddKeyedScoped<ICacheManager, InMemoryCache>(serviceKey);
    return builder;
  }
}
