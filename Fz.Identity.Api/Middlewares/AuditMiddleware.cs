using Fz.Core.Persistence.Abstractions;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Middlewares;

public class AuditMiddleware
{
  private readonly RequestDelegate _next;
  public AuditMiddleware(RequestDelegate next) => _next = next;

  public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
  {
    var request = context.Request;

    if ((request.Method == HttpMethods.Post || request.Method == HttpMethods.Put || request.Method == HttpMethods.Delete) && request.Path != "/api/v1/auth/login")
    {
      var dbContext = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
      var unitOfWork = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
      var identityManager = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

      request.EnableBuffering();

      string body = string.Empty;
      using (var reader = new StreamReader(request.Body, leaveOpen: true))
      {
        body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
      }

      var log = new AuditLog
      {
        Action = request.Method,
        Endpoint = request.Path,
        Payload = body,
        UserId = identityManager.CurrentUserId,
      };

      dbContext.Add(log);
      await unitOfWork.SaveChangesAsync();
    }

    await _next(context);
  }
}
