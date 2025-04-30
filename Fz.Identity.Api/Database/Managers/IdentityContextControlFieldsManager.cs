using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Constants;
using System.Security.Claims;

namespace Fz.Identity.Api.Database.Managers;

public sealed class IdentityContextControlFieldsManager(IHttpContextAccessor httpContextAccessor)
  : ContextControlFieldsManager<Guid>(httpContextAccessor, ClaimTypes.NameIdentifier), IIdentityContextControlFieldsManager
{
  public int? ApplicationId
  {
    get
    {
      string? applicationId = _context.HttpContext?.User?.FindFirst(IdentityClaimTypes.ApplicationId)?.Value;
      return applicationId != null ? int.Parse(applicationId) : null;
    }
  }

  public IEnumerable<Guid> RoleIds
  {
    get
    {
      IEnumerable<string> roleIds = _context.HttpContext?.User?.FindAll(ClaimTypes.Role)?.Select(row => row.Value) ?? Enumerable.Empty<string>();
      return roleIds.Select(Guid.Parse);
    }
  }
}
