using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;

namespace Finanzauto.Identity.Api.Domain.Entities.Identity;

public class User : Entity<Guid>
{
  public string? DocumentTypeId { get; set; }
  public string? DocumentNumber { get; set; }
  public string FirstName { get; set; }
  public string? SecondName { get; set; }
  public string FirstLastName { get; set; }
  public string SecondLastName { get; set; }

  public virtual ContactInfo ContactInfo { get; set; } = default!;
  public virtual ICollection<UserRole> AsignedRoles { get; set; } = default!;
  public virtual ICollection<DomainCredential> Credentials { get; set; } = default!;
  public virtual ICollection<SingleCredential> SingleCredentials { get; set; } = default!;
  public virtual ICollection<UserClaim> Claims { get; set; } = default!;

  public User(
    string? documentTypeId,
    string? documentNumber,
    string firstName,
    string? secondName,
    string firstLastName,
    string secondLastName
  )
  {
    DocumentTypeId = documentTypeId;
    DocumentNumber = documentNumber;
    FirstName = firstName;
    SecondName = secondName;
    FirstLastName = firstLastName;
    SecondLastName = secondLastName;
  }

#pragma warning disable CS8618
  public User() { }
#pragma warning restore CS8618
}
