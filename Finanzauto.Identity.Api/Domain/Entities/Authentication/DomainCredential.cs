using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Entities.Identity;

namespace Finanzauto.Identity.Api.Domain.Entities.Authentication;

public class DomainCredential : Entity<Guid>
{
  public Guid UserId { get; set; }
  public string UserName { get; set; }
  public int LoginTypeId { get; set; }
  public bool LoginConfirmed { get; set; }
  public DateTime? LoginExpiresAtUtc { get; set; }

  public virtual User User { get; set; } = default!;
  public virtual LoginType LoginType { get; set; } = default!;

  public DomainCredential(
    Guid userId,
    string userName,
    int loginTypeId,
    bool loginConfirmed,
    DateTime? loginExpiresAtUtc
  )
  {
    UserId = userId;
    UserName = userName;
    LoginTypeId = loginTypeId;
    LoginConfirmed = loginConfirmed;
    LoginExpiresAtUtc = loginExpiresAtUtc;
  }

#pragma warning disable CS8618
  public DomainCredential() { }
#pragma warning restore CS8618
}
