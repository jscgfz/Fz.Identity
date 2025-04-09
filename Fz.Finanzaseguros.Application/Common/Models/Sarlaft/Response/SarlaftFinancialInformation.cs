namespace Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;

public sealed record SarlaftFinancialInformation(
  Guid? Id,
  string? ProductType,
  double? Assets,
  double? Liabilities,
  double? Legacy,
  double? MonthlyIncome,
  double? OtherIncome,
  string? OtherIncomeConcept,
  double? MonthlyExpenses,
  bool? IsPEP,
  bool? HasPEPFamilyLink,
  bool? HandlesPublicResources,
  bool? HasForeignTaxObligations,
  string? TaxObligationsCountry,
  bool? PerformsInternationalTransaction,
  string? InternationalTransaction,
  bool? IsRUTResponsible,
  Guid? ReponsibilityCodeId,
  string? ReponsibilityCode,
  string? DianRegisteredEmail,
  string? FundsOrigin,
  bool? PerformsForeignCurrencyOperations,
  string? ForeignCurrencyOperations
);
