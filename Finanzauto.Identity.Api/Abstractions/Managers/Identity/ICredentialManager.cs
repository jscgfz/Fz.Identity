using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Models.Credential.Dtos;
using MediatR;

namespace Finanzauto.Identity.Api.Abstractions.Managers.Identity;

public interface ICredentialManager
{
  Task<Result<Unit>> Registry(Guid UserId, IEnumerable<CreateCredentialDto> credentials, CancellationToken cancellationToken);
}
