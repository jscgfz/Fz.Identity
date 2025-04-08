using System.Security.Claims;

namespace Fz.Identity.Api.Models.Identity;

public sealed record ClaimStorage
{
  public string Type { get; init; }
  public string Value { get; init; }

  public ClaimStorage(string type, string value) => (Type, Value) = (type, value);

  public static ClaimStorage FromClaim(Claim claim) => new(claim.Type, claim.Value);
  public Claim ToClaim() => new(Type, Value);
}
