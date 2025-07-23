using Finanzauto.Core.Domain.Primitives.Abstractions.Entities;

namespace Finanzauto.Identity.Api.Domain.Entities.Identity;

public class ContactInfo : IAuditableEntity<Guid>, ISoftDeleteableEntity<Guid>
{
  public Guid UserId { get; set; }
  public DateTime? CreatedAtUtc { get; set; }
  public Guid? CreatedBy { get; set; }
  public DateTime? LastModifiedAtUtc { get; set; }
  public Guid? LastModifiedBy { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? DeletedAtUtc { get; set; }
  public Guid? DeletedBy { get; set; }
  public string Email { get; set; }
  public bool EmailConfirmed { get; set; }
  public string? PhoneNumber { get; set; }
  public bool PhoneNumberConfirmed { get; set; }
  public string? Address { get; set; }

  public virtual User User { get; set; } = default!;

  public ContactInfo(
    Guid userId,
    string email,
    bool emailConfirmed,
    string? phoneNumber,
    bool phoneNumberConfirmed,
    string? address
  )
  {
    UserId = userId;
    Email = email;
    EmailConfirmed = emailConfirmed;
    PhoneNumber = phoneNumber;
    PhoneNumberConfirmed = phoneNumberConfirmed;
    Address = address;
  }

#pragma warning disable CS8618
  public ContactInfo() { }
#pragma warning restore CS8618
}
