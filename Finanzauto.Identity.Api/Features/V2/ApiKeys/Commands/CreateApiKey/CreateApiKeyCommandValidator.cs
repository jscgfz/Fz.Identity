using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.ApiKeys.Commands.CreateApiKey;

public sealed class CreateApiKeyCommandValidator : AbstractValidator<CreateApiKeyCommand>
{
  public CreateApiKeyCommandValidator(IReadOnlyDbContext context)
  {
    RuleFor(row => row.Consumer)
      .NotEmpty()
      .WithMessage("Nombre de consumidor obligatorio");

    RuleFor(row => row.AppId)
      .NotEmpty()
      .WithMessage("Identificador de la aplicación obligatorio")
      .Must(value => value != Guid.Empty)
      .WithErrorCode("Empty")
      .WithMessage("Identificador de la aplicación de deber ser vacio")
      .MustAsync((value, cancellationToken) => context.Repository<App>().AnyAsync(row => row.Id == value, cancellationToken))
      .WithName("App")
      .WithErrorCode("NotFound")
      .WithMessage("No se encontraron aplicaciones con el Id");

    RuleFor(row => new { row.AppId, row.Consumer })
      .MustAsync(async (value, cancellationToken) =>
        !await context.Repository<ApiKey>().AnyAsync(row => row.Consumer == value.Consumer && row.AppId == row.AppId, cancellationToken))
      .WithName("Consumer")
      .WithErrorCode("Duplicated")
      .WithMessage("El consumidor para la aplicación ya está registrado en la base de datos");
  }
}