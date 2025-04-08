using Fz.Core.Domain.Primitives;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Database.Entities;

public class CredentialType : MasterEntity<int>
{
#pragma warning disable CS8618
  private string _name;
#pragma warning restore CS8618
  public override string Name { get => _name; set => _name = Enum.TryParse(value, out CredentialTypes type) ? type.ToString() : throw new ArgumentException(); }
  public CredentialTypes Type { get => Enum.Parse<CredentialTypes>(_name); set => _name = value.ToString(); }

  public virtual IEnumerable<Credential> Credentials { get; set; } = default!;
  public virtual IEnumerable<AllowedCredential> AllowedCredentials { get; set; } = default!;
}
