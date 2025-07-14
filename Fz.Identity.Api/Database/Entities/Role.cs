using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Role : Entity<Guid>
{
  public int ApplicationId { get; set; }
  public string Name { get; set; }
  public string? ActiveDirectoryName { get; set; }
  public virtual Application Application { get; set; } = default!;
  public virtual IEnumerable<RoleClaim> RoleClaims { get; set; } = default!;
  public virtual IEnumerable<UserRole> UserRoles { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> Routes { get; set; } = default!;

  public Role(int applicationId, string name)
  {
    ApplicationId = applicationId;
    Name = name;
  }

#pragma warning disable CS8618
  public Role()
#pragma warning restore CS8618
  {
  }
}
