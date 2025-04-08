using Fz.Core.Domain.Primitives.Abstractions;

namespace Fz.Identity.Api.Database.Entities;

public class RoleRoute : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid RoleId { get; set; }
  public int RouteId { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }
  public Guid ModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid DeletedBy { get; set; }
  public int? ReadClaimId { get; set; }
  public int? CreateClaimId { get; set; }
  public int? EditClaimId { get; set; }
  public int? StatusClaimId { get; set; }
  public int? DownloadClaimId { get; set; }
  public int? SpecialConditionClaimId { get; set; }
  public virtual Role Role { get; set; } = default!;
  public virtual Route Route { get; set; } = default!;
  public virtual Claim? ReadClaim { get; set; } = default!;
  public virtual Claim? CreateClaim { get; set; } = default!;
  public virtual Claim? EditClaim { get; set; } = default!;
  public virtual Claim? StatusClaim { get; set; } = default!;
  public virtual Claim? DownloadClaim { get; set; } = default!;
  public virtual Claim? SpecialConditionClaim { get; set; } = default!;
}
