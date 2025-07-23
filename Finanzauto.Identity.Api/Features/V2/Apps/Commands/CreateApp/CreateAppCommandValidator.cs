using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Commands.CreateApp;

public sealed class CreateAppCommandValidator : AbstractValidator<CreateAppCommand>
{
  public CreateAppCommandValidator(IReadOnlyDbContext context)
  {
    RuleFor(x => x.Name)
      .NotNull()
      .WithErrorCode("NotNull")
      .WithMessage("Nombre obligatorio")
      .MustAsync(async (name, cancellationToken) => !await context.Repository<App>().AnyAsync(row => row.ApplicationName == name, cancellationToken))
      .WithErrorCode("Duplicated")
      .WithMessage("El nombre ya está registrado en la base de datos");

    RuleFor(x => x.Prefix)
      .NotNull()
      .WithErrorCode("NotNull")
      .WithMessage("Prefijo obligatorio")
      .MustAsync(async (prefix, cancellationToken) => !await context.Repository<App>().AnyAsync(row => row.Prefix == prefix, cancellationToken))
      .WithErrorCode("Duplicated")
      .WithMessage("El prefijo ya está registrado en la base de datos");

    RuleFor(x => x.DomainName)
      .MustAsync(async (domainName, cancellationToken) => domainName is null || !await context.Repository<App>().AnyAsync(row => row.DomainName == domainName, cancellationToken))
      .WithErrorCode("Duplicated")
      .WithMessage("El nombre de dominio ya está registrado en la base de datos");
  }
}
