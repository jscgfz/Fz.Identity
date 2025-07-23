namespace Finanzauto.Identity.Api.Models.ApiKey;

public sealed record ApiKeyAtomicValues(
  Guid Id,
  string Consumer,
  byte[] Hash,
  byte[] Salt,
  DateTime? CreatedAtUtc,
  Guid AppId,
  string AppName,
  string? AppDescription,
  bool MultiDomainEnabled,
  bool RootApplicationEnabled,
  bool TwoFactorAuthenticationEnabled
);
