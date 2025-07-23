using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Commands.CreateApiKey;

public sealed record CreateApiKeyCommand(
  Guid AppId,
  string Consumer
) : ICommand<ApikeyResponseDto>;