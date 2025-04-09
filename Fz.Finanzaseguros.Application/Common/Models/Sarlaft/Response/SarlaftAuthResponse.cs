namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftAuthResponse(
  string AccesToken,
  int ExpiresIn,
  DateTime ExpirationDate,
  string RefreshToken
);
