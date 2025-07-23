using FluentValidation;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Commands.Actions;

public sealed class ClaimActionsCommandValidator : AbstractValidator<ClaimActionsCommand>
{
  public ClaimActionsCommandValidator()
  {
    RuleFor(x => x.Actions)
      .NotEmpty()
      .WithMessage("Las acciones no pueden estar vacías")
      .Must(actions => actions.DistinctBy(a => a.Value).Count() == actions.Count());

    RuleForEach(x => x.Actions)
      .NotEmpty()
      .WithMessage("Cada acción debe tener valor")
      .Must(action => !string.IsNullOrWhiteSpace(action.Value))
      .WithMessage("El valor de la acción es obligatiorio")
      .Must(action => action.Value.Length <= 10)
      .WithMessage("La longitud del valor de la acción no debe exeder los 10 carácteres");
  }
}
