using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;
using Finanzauto.Identity.Api.Models.Authentication;

namespace Finanzauto.Identity.Api.Abstractions.Managers.Authentication;

public interface ICredentialResolverManager
{
  Task<Result<CredentialResolution>> ResolveCredential(LoginCommand cmd, CancellationToken cancellationToken);
}
