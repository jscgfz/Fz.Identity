using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class ClaimType : MasterEntity<int>
{
  public virtual IEnumerable<Claim> Claims { get; set; } = default!;
}
