namespace Finanzauto.Identity.Api.Abstractions.Managers;

public interface IAppConfigurationManager
{
  T Get<T>(string key) where T : class;
  T Get<T>() where T : class;
}
