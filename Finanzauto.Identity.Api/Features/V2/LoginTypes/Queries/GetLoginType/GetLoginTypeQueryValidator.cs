using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginType;

public sealed class GetLoginTypeQueryValidator : AbstractValidator<GetLoginTypeQuery>
{
  public GetLoginTypeQueryValidator(IReadOnlyDbContext context)
  {
    RuleFor(x => x.Id)
        .NotEmpty()
        .MustAsync(async (value, cancellationToken) => await context.Repository<LoginType>().AnyAsync(row => row.Id == value, cancellationToken))
        .WithErrorCode("Invalid")
        .WithMessage("Login Invalido");
  }
}
