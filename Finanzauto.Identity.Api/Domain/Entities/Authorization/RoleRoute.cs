using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Authorization;

public class RoleRoute : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid RoleId { get; set; }
  public Guid RouteId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }

  public virtual Role Role { get; set; } = null!;
  public virtual Configuration.Route Route { get; set; } = null!;
}
