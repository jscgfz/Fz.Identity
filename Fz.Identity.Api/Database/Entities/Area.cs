using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Area : MasterEntity<int>
{
  public virtual IEnumerable<User>? Users { get; set; }
}
