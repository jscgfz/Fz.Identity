using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class LoginLog : Entity<Guid>
{
  public Guid UserId { get; set; }
  public int ApplicationId { get; set; }
  public string Location { get; set; }
  public DateTime ClaimedAtUtc { get; set; }
  public DateTime? LastTransactionAtUtc { get; set; }
  public virtual UserApplication UserApplication { get; set; } = default!;

  public LoginLog(Guid userId, int applicationId, string location, DateTime claimedAtUtc, DateTime? lastTransactionAtUtc)
  {
    UserId = userId;
    ApplicationId = applicationId;
    Location = location;
    ClaimedAtUtc = claimedAtUtc;
    LastTransactionAtUtc = lastTransactionAtUtc;
  }

#pragma warning disable CS8618
  public LoginLog() { }
#pragma warning restore CS8618
}
