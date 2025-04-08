using Fz.Core.Domain.Primitives;
using System.Text.Json;

namespace Fz.Identity.Api.Database.Entities;

public class Credential : Entity<int>
{
  public Guid UserId { get; set; }
  public int CredentialTypeId { get; set; }
  public JsonElement CredentialValue { get; set; }
  public DateTime? CredentialEndUtc { get; set; }
  public bool CredentialConfirmed { get; set; }
  public bool TwoFactorEnabled { get; set; }
  public virtual User User { get; set; } = default!;
  public virtual CredentialType CredentialType { get; set; } = default!;

  public Credential(Guid userId, int credentialTypeId, JsonElement credentialValue)
  {
    UserId = userId;
    CredentialTypeId = credentialTypeId;
    CredentialValue = credentialValue;
  }

#pragma warning disable CS8618
  public Credential()
#pragma warning restore CS8618
  {
  }
}
