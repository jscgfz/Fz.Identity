using Fz.Finanzaseguros.Application.Abstractions.Services;
using Fz.Finanzaseguros.Infrastructure.Configuration.Delegates;
using Fz.Finanzaseguros.Infrastructure.Configuration.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace Fz.Finanzaseguros.Infrastructure.Extensions;

public static class Dependencyinjection
{
  public static WebApplicationBuilder WithInfrastructure(this WebApplicationBuilder builder)
  {
    builder.Services
      .AddOptions<MpmServiceSettings>()
      .BindConfiguration(nameof(MpmServiceSettings))
      .ValidateDataAnnotations()
      .ValidateOnStart();

    builder.Services
      .AddOptions<SarlaftServiceSettings>()
      .BindConfiguration(nameof(SarlaftServiceSettings))
      .ValidateDataAnnotations()
      .ValidateOnStart();

    builder
      .Services
      .AddRefitClient<IMpmService>()
      .ConfigureHttpClient((provider, client) =>
      {
        MpmServiceSettings settings = provider.GetRequiredService<IOptions<MpmServiceSettings>>().Value;
        client.BaseAddress = new(settings.BaseUrl);
      })
      .AddHttpMessageHandler<MpmAuthenticationDelegate>();

    builder.Services
      .AddRefitClient<ISarlaftService>()
      .ConfigureHttpClient((provider, client) =>
      {
        SarlaftServiceSettings settings = provider.GetRequiredService<IOptions<SarlaftServiceSettings>>().Value;
        client.BaseAddress = new(settings.BaseUrl);
      })
      .AddHttpMessageHandler<SarlaftAuthenticationDelegate>();

    return builder;
  }
}
