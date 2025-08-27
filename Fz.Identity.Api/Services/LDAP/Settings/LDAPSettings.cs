namespace Fz.Identity.Api.Services.LDAP.Settings;

public sealed class LDAPSettings
{

  public string BaseUrl { get; set; }
  public string Signature { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  public LDAPSettings()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  {
  }
}
