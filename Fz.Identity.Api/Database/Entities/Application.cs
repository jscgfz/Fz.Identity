using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Application : MasterEntity<int>
{
  public virtual IEnumerable<Role> Roles { get; set; } = default!;
  public virtual IEnumerable<UserClaim> UserClaims { get; set; } = default!;
  public virtual IEnumerable<AllowedCredential> AllowedCredentials { get; set; } = default!;
  public virtual IEnumerable<UserApplication> Users { get; set; } = default!;
  public virtual IEnumerable<Route> Routes { get; set; } = default!;
}
