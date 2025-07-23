using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Authorization;

public class RoleClaim : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid RoleId { get; set; }
  public Guid ClaimValueId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }

  public virtual Role Role { get; set; } = default!;
  public virtual ClaimValue ClaimValue { get; set; } = default!;

  public RoleClaim(Guid roleId, Guid claimValueId)
  {
    RoleId = roleId;
    ClaimValueId = claimValueId;
  }

  public RoleClaim()
  {
  }
}
