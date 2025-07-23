using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Query.VerifyApiKey;

public sealed record VerifyApiKeyQuery(
  string ApiKey
) : IQuery<ApikeyDetailsDto>;
