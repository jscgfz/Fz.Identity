namespace Fz.Identity.Api.Database.Entities;

public class AllowedCredential
{
  public int CredentialTypeId { get; set; }
  public int ApplicationId { get; set; }

  public virtual CredentialType CredentialType { get; set; } = default!;
  public virtual Application Application { get; set; } = default!;
}
