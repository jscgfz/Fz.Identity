using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Common;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginTypes;

public sealed class GetLoginTypesQueryHandler(IServiceProvider provider) : IQueryHandler<GetLoginTypesQuery, IEnumerable<LoginTypeOptionDto>>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public async Task<Result<IEnumerable<LoginTypeOptionDto>>> Handle(GetLoginTypesQuery request, CancellationToken cancellationToken)
  {
    IEnumerable<LoginTypeOptionDto> loginTypes = await _context
      .Repository<LoginType>()
      .Select(row => new LoginTypeOptionDto(row.Id, row.Name))
      .ToListAsync(cancellationToken);

    if (!loginTypes.Any())
      return Result.Failure<IEnumerable<LoginTypeOptionDto>>(ResultTypes.NotFound, new Error("LoginTypes.NotFound", "No hay logins disponibles"));

    return loginTypes.Success();
  }
}
