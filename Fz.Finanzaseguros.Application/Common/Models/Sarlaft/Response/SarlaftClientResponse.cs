namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftClientResponse(
  Guid Id,
  SarlaftPersonResponse Person,
  SarlaftPersonResponse LegalRepresentative,
  SarlaftFinancialInformation FinancialInformation
);
