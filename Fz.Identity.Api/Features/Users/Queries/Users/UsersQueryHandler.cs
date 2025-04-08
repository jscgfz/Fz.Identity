using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Features.Users.Queries.Users;

public sealed class UsersQueryHandler(IServiceProvider provider) : IQueryHandler<UsersQuery, Result<IPaginatedResult<UserDto>>>
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);

  public Task<Result<IPaginatedResult<UserDto>>> Handle(UsersQuery request, CancellationToken cancellationToken)
#pragma warning disable CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
    => SpecificationResolver.ComputeResult(
        UserSpecifications.ByUsersQuery,
        request,
        _context,
        [new Error("Users.NotFound", "no se encontraron usuarios para la consulta")]
      );
#pragma warning restore CS8620 // El argumento no se puede usar para el parámetro debido a las diferencias en la nulabilidad de los tipos de referencia.
}
