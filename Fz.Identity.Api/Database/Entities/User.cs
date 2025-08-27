using Fz.Core.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Fz.Identity.Api.Database.Entities;

public class User : Entity<Guid>
{
  [Display(Name = "Nombres")]
  public string Name { get; set; }

  [Display(Name = "Apellidos")]
  public string Surname { get; set; }

  [Display(Name = "Usuario")]
  public string Username { get; set; }

  [Display(Name = "Número de identificación")]
  public string? IdentificationNumber { get; set; }

  [Display(Name = "Correo")]
  public string PrincipalEmail { get; set; }
  public bool PrincipalEmailConfirmed { get; set; }

  [Display(Name = "Número de teléfono")]
  public string? PrincipalPhoneNumber { get; set; }
  public bool PrincipalPhoneNumberConfirmed { get; set; }

  [Display(Name = "Tipo documento")]
  public string? DocumentType { get; set; }
  public string? PhotoNodeId { get; set; }
  public int? AreaId { get; set; }

  public virtual IEnumerable<UserClaim> UserClaims { get; set; } = default!;
  public virtual IEnumerable<Credential> Credentials { get; set; } = default!;
  public virtual IEnumerable<UserRole> Roles { get; set; } = default!;
  public virtual IEnumerable<UserApplication> Applications { get; set; } = default!;
  public virtual Area? Area { get; set; }

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
