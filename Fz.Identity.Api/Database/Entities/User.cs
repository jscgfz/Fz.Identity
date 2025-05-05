using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class User : Entity<Guid>
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public string Username { get; set; }
  public string IdentificationNumber { get; set; }
  public string PrincipalEmail { get; set; }
  public bool PrincipalEmailConfirmed { get; set; }
  public string PrincipalPhoneNumber { get; set; }
  public bool PrincipalPhoneNumberConfirmed { get; set; }
  public string DocumentType { get; set; }

  public virtual IEnumerable<UserClaim> UserClaims { get; set; } = default!;
  public virtual IEnumerable<Credential> Credentials { get; set; } = default!;
  public virtual IEnumerable<UserRole> Roles { get; set; } = default!;
  public virtual IEnumerable<UserApplication> Applications { get; set; } = default!;

  public User(
    string name,
    string surname,
    string username,
    string identificationNumber,
    string principalEmail,
    bool principalEmailConfirmed,
    string principalPhonNumber,
    bool principalPhoneNumberConfirmed
  )
  {
    Name = name;
    Surname = surname;
    Username = username;
    IdentificationNumber = identificationNumber;
    PrincipalEmail = principalEmail;
    PrincipalEmailConfirmed = principalEmailConfirmed;
    PrincipalPhoneNumber = principalPhonNumber;
    PrincipalPhoneNumberConfirmed = principalPhoneNumberConfirmed;
  }

#pragma warning disable CS8618
  public User()
#pragma warning restore CS8618
  {
  }
}
