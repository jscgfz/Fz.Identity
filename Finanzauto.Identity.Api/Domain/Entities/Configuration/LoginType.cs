using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Enums.Authentication;

namespace Finanzauto.Identity.Api.Domain.Entities.Configuration;

public class LoginType : MasterEntity<int>
{
  public string? DomainName { get; set; }
  public string? Key { get; set; }
  public AuthenticationTypes AuthenticationType { get; set; }

  public virtual ICollection<LoginApp> AllowedApps { get; set; } = default!;
  public virtual ICollection<DomainCredential> Credentials { get; set; } = default!;

  public LoginType(string name, string? description, string? domainName, string? key, AuthenticationTypes authenticationType)
  {
    Name = name;
    Description = description;
    DomainName = domainName;
    Key = key;
    AuthenticationType = authenticationType;
  }

  public LoginType(string name, string? domainName)
  {
    Name = name;
    DomainName = domainName;
  }

  public LoginType() { }
}
