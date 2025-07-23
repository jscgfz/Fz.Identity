using Finanzauto.Core.Domain.Primitives;

namespace Finanzauto.Identity.Api.Domain.Entities.HigherOrder;

public class HigherOrderKey : Entity<Guid>
{
  public byte[] SignatureKey { get; set; }

  public virtual ICollection<HigherOrderEndpointOrigin> AllowedEndpoints { get; set; } = default!;

  public HigherOrderKey(byte[] signatureKey)
  {
    SignatureKey = signatureKey;
  }

#pragma warning disable CS8618
  public HigherOrderKey() { }
#pragma warning restore CS8618
}
