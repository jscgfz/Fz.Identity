using Finanzauto.Core.Domain.Primitives;

namespace Finanzauto.Identity.Api.Domain.Entities.Claims;

public class ClaimSection : MasterEntity<int>
{
  public ICollection<ClaimValue> Actions { get; set; } = default!;
}
