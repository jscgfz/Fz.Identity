namespace Fz.Identity.Api.Services.Alfresco.Settings;

public sealed class AlfrescoSettings
{
  public string BaseUrl { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
  public string PhotoNode { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  public AlfrescoSettings()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  {
  }
}
