using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Commands.Actions;

public sealed class ClaimActionsCommandHandler(IServiceProvider provider) : ICommandHandler<ClaimActionsCommand, IEnumerable<ClaimResponseDto>>
{
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();

  public async Task<Result<IEnumerable<ClaimResponseDto>>> Handle(ClaimActionsCommand request, CancellationToken cancellationToken)
  {
    IEnumerable<ClaimRequestDto> actions = request.Actions
      .GroupBy(a => a.Value)
      .Select(g => new ClaimRequestDto(g.Key, g.Select(a => a.Description).Aggregate((acc, curr) => $"{acc}, {curr}")));

    IEnumerable<string> keys = actions.Select(a => a.Value).Distinct();

    IEnumerable<ClaimAction> claimActions = await _context.Repository<ClaimAction>()
      .Where(a => keys.Contains(a.Name))
      .ToListAsync(cancellationToken);

    foreach (ClaimAction action in claimActions)
    {
      action.Description = actions.First(a => a.Value == action.Name).Description;
      _context.Update(action);
    }

    foreach (ClaimRequestDto action in actions.Where(a => !claimActions.Select(c => c.Name).Contains(a.Value)))
    {
      ClaimAction newAction = new()
      {
        Name = action.Value,
        Description = action.Description
      };
      _context.Add(newAction);
      claimActions = claimActions.Append(newAction);
    }

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return claimActions
      .Select(a => new ClaimResponseDto(a.Id, a.Name, a.Description))
      .Success();
  }
}
