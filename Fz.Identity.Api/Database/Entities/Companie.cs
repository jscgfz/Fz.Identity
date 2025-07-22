using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Company : MasterEntity<int>
{
  public virtual IEnumerable<Application> Applications { get; set; } = default!;
}
