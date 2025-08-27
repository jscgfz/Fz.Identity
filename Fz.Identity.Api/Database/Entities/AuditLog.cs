using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class AuditLog : Entity<Guid>
{

  public string Action { get; set; } = default!;
  public string Module { get; set; } = default!;
  public string Description { get; set; }
  public string Entity { get; set; }
  public string EntityId { get; set; }
  public Guid UserId { get; set; }
  public int ApplicationId { get; set; }
  public virtual User User { get; set; }
  public virtual Application Application { get; set; }

  public AuditLog()
  {
  }
}
