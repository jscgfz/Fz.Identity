namespace Finanzauto.Identity.Api.Models.Managers.Hashing;

public sealed record HashRequest(
  string Data,
  byte[] Hash,
  byte[] Salt
);
