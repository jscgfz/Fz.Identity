using Finanzauto.Identity.Api.Abstractions.Managers;

namespace Finanzauto.Identity.Api.Managers;

public sealed class AppConfigurationManager(IConfiguration config) : IAppConfigurationManager
{
  private readonly IConfiguration _config = config;

  public T Get<T>(string key) where T : class
    => _config.GetSection(key).Get<T>() ?? throw new InvalidOperationException($"Configuration section '{key}' not found or is not of type {typeof(T).Name}.");
  public T Get<T>() where T : class
    => _config.GetSection(typeof(T).Name).Get<T>() ?? throw new InvalidOperationException($"Configuration section of type {typeof(T).Name} not found.");
}
