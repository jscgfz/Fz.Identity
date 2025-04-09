namespace Fz.Finanzaseguros.Infrastructure.Configuration.Settings;

public sealed class SarlaftServiceSettings
{
  public string BaseUrl { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }

  public SarlaftServiceSettings(string baseUrl, string userName, string password)
  {
    BaseUrl = baseUrl;
    UserName = userName;
    Password = password;
  }

#pragma warning disable CS8618
  public SarlaftServiceSettings() { }
#pragma warning restore CS8618
}
