using FluentValidation;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Query.VerifyApiKey;

public sealed class VerifyApiKeyQueryValidator : AbstractValidator<VerifyApiKeyQuery>
{
  public VerifyApiKeyQueryValidator()
  {
    RuleFor(row => row.ApiKey)
      .NotEmpty()
      .WithMessage("Api key obligatoria");
  }
}
