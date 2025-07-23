using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;

namespace Finanzauto.Identity.Api.Domain.Entities.Claims;

public class ClaimValue : Entity<Guid>
{
  public int ClaimSectionId { get; set; }
  public int ClaimActionId { get; set; }

  public virtual ClaimSection ClaimSection { get; set; } = default!;
  public virtual ClaimAction ClaimAction { get; set; } = default!;

  public virtual ICollection<UserClaim> Users { get; set; } = default!;
  public virtual ICollection<RoleClaim> Roles { get; set; } = default!;
  public virtual ICollection<ApiKeyClaim> ApiKeys { get; set; } = default!;

  public ClaimValue(int claimSectionId, int claimActionId)
  {
    ClaimSectionId = claimSectionId;
    ClaimActionId = claimActionId;
  }

  public ClaimValue() { }
}
