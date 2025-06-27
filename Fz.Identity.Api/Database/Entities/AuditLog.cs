using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class AuditLog : Entity<Guid>
{

  public string Action { get; set; } = default!;
  public string Endpoint { get; set; } = default!;
  public string? Payload { get; set; }
  public Guid UserId { get; set; }
  public virtual User User { get; set; }

  public AuditLog()
  {
  }
}
