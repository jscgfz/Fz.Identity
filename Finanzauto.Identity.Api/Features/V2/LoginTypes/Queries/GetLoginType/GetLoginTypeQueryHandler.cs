using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Common;
using Finanzauto.Core.Result.Extensions.Handlers;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginType;

public sealed class GetLoginTypeQueryHandler(IServiceProvider provider) : IQueryHandler<GetLoginTypeQuery, LoginTypeDetailDto>
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();

  public async Task<Result<LoginTypeDetailDto>> Handle(GetLoginTypeQuery request, CancellationToken cancellationToken)
    => await _context
      .Repository<LoginType>()
      .Where(row => row.Id == request.Id)
      .Select(row => new LoginTypeDetailDto(row.Id, row.Name, row.Description, row.DomainName, row.Key, row.AuthenticationType))
      .FirstOrDefaultAsync(cancellationToken) is LoginTypeDetailDto dto ? dto.Success()
        : Result.Failure<LoginTypeDetailDto>(ResultTypes.NotFound, new Error("LoginType.NotFound", "Login no encontrado"));
}
