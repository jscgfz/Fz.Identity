using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;
using Finanzauto.Identity.Api.Models.Authentication;

namespace Finanzauto.Identity.Api.Abstractions.Managers.Authentication;

public interface ITokenProviderManager
{
  Task<Result<TokenResponseDto>> FromResolution(CredentialResolution credentialResolution, CancellationToken cancellationToken);
  Task<Result<string>> FromApiKey(string apiKey, CancellationToken cancellationToken);
  Task<Result<TokenResponseDto>> Refresh(CancellationToken cancellationToken);
}
