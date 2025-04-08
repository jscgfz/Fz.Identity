namespace Fz.Finanzaseguros.Infrastructure.Configuration.Settings;

public sealed class MpmServiceSettings
{
  public string BaseUrl { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }
  public int TokenExpiraionInMinutes { get; set; }

  public MpmServiceSettings(string baseUrl, string userName, string password, int tokenExpiraionInMinutes)
  {
    BaseUrl = baseUrl;
    UserName = userName;
    Password = password;
    TokenExpiraionInMinutes = tokenExpiraionInMinutes;
  }

#pragma warning disable CS8618
  public MpmServiceSettings() { }
#pragma warning restore CS8618
}
