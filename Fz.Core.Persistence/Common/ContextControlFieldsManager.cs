using Fz.Core.Persistence.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Fz.Core.Persistence.Common;

public class ContextControlFieldsManager<TUser>(IHttpContextAccessor context, string key) : IContextControlFieldsManager<TUser>
  where TUser : IEquatable<TUser>
{
  protected readonly IHttpContextAccessor _context = context;
  protected readonly string _key = key;

  public virtual DateTime UtcNow => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
  public virtual TUser CurrentUserId
  {
    get
    {
      string? userId = _context.HttpContext?.User?.FindFirst(_key)?.Value;
      if(userId is not null)
        return typeof(TUser).GetMethods().Where(m => m.Name == "Parse" && m.GetParameters().Length == 1).FirstOrDefault() is not null
        ? (TUser)typeof(TUser).GetMethods().Where(m => m.Name == "Parse" && m.GetParameters().Length == 1).First()!.Invoke(null, [userId])!
        : throw new InvalidCastException(typeof(TUser).Name);
      else
        return Guid.Empty is TUser defaultValue ? defaultValue : throw new NullReferenceException();
    }
  }
}
