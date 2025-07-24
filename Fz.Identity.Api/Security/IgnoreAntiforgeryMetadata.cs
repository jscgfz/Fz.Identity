using Microsoft.AspNetCore.Antiforgery;

namespace Fz.Identity.Api.Security;

public sealed class IgnoreAntiforgeryMetadata : IAntiforgeryMetadata
{
  public static readonly IgnoreAntiforgeryMetadata Instance = new();
  private IgnoreAntiforgeryMetadata() { }

  public bool RequiresValidation => false;
}
