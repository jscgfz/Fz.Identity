using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
  public LoginCommandValidator(IReadOnlyDbContext context)
  {
    RuleFor(row => row)
      .Must(row => row.ApplicationId.HasValue || row.ApplicationIndex.HasValue)
      .WithName("Application")
      .WithErrorCode("Required")
      .WithMessage("Identificador de la aplicación o índice de la aplicación obligatorio")
      .MustAsync(async (row, cancellationToken) =>
        (row.ApplicationId.HasValue && await context.Repository<App>().AnyAsync(app => app.Id == row.ApplicationId, cancellationToken)) ||
        (row.ApplicationIndex.HasValue && await context.Repository<App>().AnyAsync(app => app.AppIndex == row.ApplicationIndex, cancellationToken)))
      .WithName("Application")
      .WithErrorCode("NotFound")
      .WithMessage("La aplicación no existe o no está configurada correctamente");


    //RuleFor(row => row.ApplicationId)
    //  .NotEmpty()
    //  .WithMessage("Identificador de la aplicación obligatorio")
    //  .MustAsync((id, cancellationToken) => context.Repository<App>().AnyAsync(row => row.Id == id, cancellationToken))
    //  .WithName("Application")
    //  .WithErrorCode("NotFound")
    //  .WithMessage("La aplicación no existe");

    RuleFor(row => row.UserName)
      .NotEmpty()
      .WithMessage("Nombre de usuario obligatorio")
      .MaximumLength(256)
      .WithMessage("El nombre de usuario no puede tener más de 256 caracteres");
  }
}
