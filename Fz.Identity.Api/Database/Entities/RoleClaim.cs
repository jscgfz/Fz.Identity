using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class RoleClaim : Entity<int>
{
  public Guid RoleId { get; set; }
  public int ClaimId { get; set; }
  public virtual Role Role { get; set; } = default!;
  public virtual Claim Claim { get; set; } = default!;
}
