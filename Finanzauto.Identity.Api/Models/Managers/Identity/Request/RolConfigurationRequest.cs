namespace Finanzauto.Identity.Api.Models.Managers.Identity.Request;

public sealed record RolConfigurationRequest(
  Guid UserId,
  IEnumerable<Guid>? Adds,
  IEnumerable<Guid>? Removes
);
