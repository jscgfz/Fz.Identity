using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Models.Apps.Dtos;

namespace Finanzauto.Identity.Api.Abstractions.Managers;

public interface IAppManager
{
  Task<Result<IEnumerable<UserAppResumeDto>>> UserInfo(Guid userId, CancellationToken cancellationToken);
}
