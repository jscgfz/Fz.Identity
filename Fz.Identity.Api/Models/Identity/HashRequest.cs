namespace Fz.Identity.Api.Models.Identity;

public sealed record HashRequest(
  string Data,
  byte[] Hash,
  byte[] Salt
);
