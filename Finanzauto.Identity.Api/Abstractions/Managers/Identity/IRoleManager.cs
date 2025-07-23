using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Models.Managers.Identity.Request;
using MediatR;

namespace Finanzauto.Identity.Api.Abstractions.Managers.Identity;

public interface IRoleManager
{
  Task<Result<Unit>> Configure(RolConfigurationRequest request, CancellationToken cancellationToken);
}
