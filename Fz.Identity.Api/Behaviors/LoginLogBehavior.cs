using Fz.Core.Persistence.Abstractions;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Behaviors;

public sealed class LoginLogBehavior<TRequest, TResponse>(IServiceProvider provider) : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull, IRequest<TResponse>
{
  private readonly IDbContext _context = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IHttpContextAccessor _contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);

  public async Task<TResponse> Handle(TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken)
  {
    if (
      _contextAccessor.HttpContext is HttpContext context &&
      context.User.FindFirst(IdentityClaimTypes.TraceIdentifier) is System.Security.Claims.Claim claim &&
      Guid.TryParse(claim.Value, out Guid traceidentifier) &&
      await _context.Repository<LoginLog>().FirstOrDefaultAsync(x => x.Id == traceidentifier, cancellationToken) is LoginLog log
    )
    {
      log.LastTransactionAtUtc = DateTime.UtcNow;
      _context.Update(log);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    return await next();
  }
}
