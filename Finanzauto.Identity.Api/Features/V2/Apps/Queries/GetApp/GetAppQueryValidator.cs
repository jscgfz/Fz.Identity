using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApp;

public sealed class GetAppQueryValidator : AbstractValidator<GetAppQuery>
{
  public GetAppQueryValidator(IReadOnlyDbContext context)
  {
    RuleFor(row => row.Id)
      .NotEmpty()
      .WithMessage("Identificador de la aplicación obligatorio")
      .MustAsync((value, cancellationToken) => context.Repository<App>().AnyAsync(row => row.Id == value, cancellationToken))
      .WithErrorCode("NotFound")
      .WithMessage("Applicación no encontrada");
  }
}