using Finanzauto.Core.Domain.Primitives;

namespace Finanzauto.Identity.Api.Domain.Entities.Claims;

public class ClaimAction : MasterEntity<int>
{
  public virtual ICollection<ClaimValue> Sections { get; set; } = default!;
}
