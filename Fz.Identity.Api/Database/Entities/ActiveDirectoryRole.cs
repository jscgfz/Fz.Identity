using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class ActiveDirectoryRole : Entity<Guid>
{
  public string Name { get; set; }
  public int ApplicationId { get; set; }

  public virtual Application Application { get; set; }
  public virtual Role Role { get; set; }
}
