namespace Fz.Identity.Api.Features.Reports.Dtos;

public sealed record LoginLogDto(
  Guid UserId,
  string UserName,
  int ApplicationId,
  string ApplicationName,
  string? Ip,
  DateTime TokenClaimRegisteredUtcDate,
  DateTime? TokenLastUsedTransactionUtcDate
)
{
  public TimeSpan TokenUsageElapsedTime => (TokenLastUsedTransactionUtcDate ?? TokenClaimRegisteredUtcDate) - TokenClaimRegisteredUtcDate;
}
