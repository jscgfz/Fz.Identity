using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;

namespace Finanzauto.Identity.Api.Domain.Entities.HigherOrder;

public class HigherOrderEndpointOrigin : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }
  public Guid EndpointId { get; set; }
  public Guid KeyId { get; set; }

  public virtual HigherOrderKey Key { get; set; } = default!;
  public virtual HigherOrderEndpoint Endpoint { get; set; } = default!;


  public HigherOrderEndpointOrigin(Guid endpointId, Guid keyId)
  {
    EndpointId = endpointId;
    KeyId = keyId;
  }

  public HigherOrderEndpointOrigin() { }
}
