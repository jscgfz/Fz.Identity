using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Configuration;

public class App : Entity<Guid>
{
  public int AppIndex { get; set; }
  public string ApplicationName { get; set; }
  public string? Description { get; set; }
  public string Prefix { get; set; }
  public string? DomainName { get; set; }
  public bool MultiDomainEnabled { get; set; }
  public bool RootApplicationEnabled { get; set; }
  public bool TwoFactorEnabled { get; set; }

  public virtual AppSafety Safety { get; set; } = default!;

  public virtual ICollection<ApiKey> ApiKeys { get; set; } = default!;
  public virtual ICollection<LoginApp> AllowedLogins { get; set; } = default!;
  public virtual ICollection<Role> Roles { get; set; } = default!;
  public virtual ICollection<SingleCredential> SingleCredentials { get; set; } = default!;
  public virtual ICollection<UserClaim> UserClaims { get; set; } = default!;

  public App(
    string applicationName,
    string? description,
    string prefix,
    string? domainName,
    bool multiDomainEnabled,
    bool rootApplicationEnabled,
    bool twoFactorEnabled
  )
  {
    ApplicationName = applicationName;
    Description = description;
    Prefix = prefix;
    DomainName = domainName;
    MultiDomainEnabled = multiDomainEnabled;
    RootApplicationEnabled = rootApplicationEnabled;
    TwoFactorEnabled = twoFactorEnabled;
  }

#pragma warning disable CS8618
  public App() { }
#pragma warning restore CS8618
}
