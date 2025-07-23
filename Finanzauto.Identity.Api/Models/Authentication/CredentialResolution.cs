namespace Finanzauto.Identity.Api.Models.Authentication;

public sealed record CredentialResolution(
  Guid UserId,
  Guid ApplicationId,
  IEnumerable<string> DomainRoles
);
