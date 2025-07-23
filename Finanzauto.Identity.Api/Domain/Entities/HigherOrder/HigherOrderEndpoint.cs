using Finanzauto.Core.Domain.Primitives;

namespace Finanzauto.Identity.Api.Domain.Entities.HigherOrder;

public class HigherOrderEndpoint : Entity<Guid>
{
  public string Method { get; set; }
  public string Route { get; set; }
  public bool RequiresSecondAuthLayer { get; set; }
  public bool RequiresThirdAuthLayer { get; set; }

  public virtual ICollection<HigherOrderEndpointOrigin> AlloweOrigins { get; set; } = default!;

  public HigherOrderEndpoint(
    string method,
    string route,
    bool requiresSecondAuthLayer,
    bool requiresThirdAuthLayer
  )
  {
    Method = method;
    Route = route;
    RequiresSecondAuthLayer = requiresSecondAuthLayer;
    RequiresThirdAuthLayer = requiresThirdAuthLayer;
  }

#pragma warning disable CS8618
  public HigherOrderEndpoint() { }
#pragma warning restore CS8618
}
