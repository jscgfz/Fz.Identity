using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Constants;
using System.Security.Claims;

namespace Fz.Identity.Api.Database.Managers;

public sealed class IdentityContextControlFieldsManager(IHttpContextAccessor httpContextAccessor) : IIdentityContextControlFieldsManager
{
  private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

  public DateTime UtcNow => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));

  public Guid CurrentUserId
  {
    get
    {
      string? userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      return userId != null ? Guid.Parse(userId) : Guid.Empty;
    }
  }

  public int? ApplicationId
  {
    get
    {
      string? applicationId = _httpContextAccessor.HttpContext?.User?.FindFirst(IdentityClaimTypes.ApplicationId)?.Value;
      return applicationId != null ? int.Parse(applicationId) : null;
    }
  }

  public IEnumerable<Guid> RoleIds
  {
    get
    {
      IEnumerable<string> roleIds = _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role)?.Select(row => row.Value) ?? Enumerable.Empty<string>();
      return roleIds.Select(Guid.Parse);
    }
  }
}
