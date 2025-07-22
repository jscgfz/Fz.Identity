using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Request : Entity<int>
{
  public Guid ResourceId { get; set; }
  public string ChangesJson { get; set; }
  public string Reason { get; set; }
  public int StatusId { get; set; }
  public DateTime? ProcessedAt { get; set; }
  public DateTime ExpireAt => CreatedAtUtc.AddDays(3);
  public string AuthorizationFileId { get; set; }
  public string AuthorizationFileName { get; set; }
  public string? RejectionReason{ get; set; }
  public int ApplicationId { get; set; }

  public virtual RequestStatus Status { get; set; }
  public virtual Application Application { get; set; }
}
