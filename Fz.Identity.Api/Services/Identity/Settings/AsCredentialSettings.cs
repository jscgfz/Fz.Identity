namespace Fz.Identity.Api.Services.Identity.Settings;

public sealed class AsCredentialSettings
{
  public string BaseUrl { get; set; }
  public string Signature { get; set; }

  public AsCredentialSettings(string baseUrl, string signature)
  {
    BaseUrl = baseUrl;
    Signature = signature;
  }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  public AsCredentialSettings()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  {
  }
}
