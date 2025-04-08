using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class UserClaim : Entity<int>
{
  public Guid UserId { get; set; }
  public int ClaimId { get; set; }
  public int ApplicationId { get; set; }
  public virtual User User { get; set; } = default!;
  public virtual Claim Claim { get; set; } = default!;
  public virtual Application Application { get; set; } = default!;
}
