using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Domain.Enums.Authentication;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
  public CreateUserCommandValidator(IServiceProvider provider)
  {
    IReadOnlyDbContext context = provider.GetRequiredService<IReadOnlyDbContext>();

    RuleFor(row => new { row.RoleIds, row.Credentials })
      .MustAsync(async (row, cancellationToken) =>
      {
        Dictionary<int, AuthenticationTypes> types = await context.Repository<LoginType>()
          .ToDictionaryAsync(row => row.Id, row => row.AuthenticationType, cancellationToken);

        return row.Credentials.All(c => types.TryGetValue(c.LoginTypeId, out AuthenticationTypes type) && type == AuthenticationTypes.DomainCredential) && row.RoleIds is null ||
          row.RoleIds is not null && row.RoleIds.Any();
      })
      .WithMessage("Debe especificar al menos un rol para el usuario con credenciales por fuera del dominio.");

    RuleForEach(row => row.RoleIds)
      .NotEmpty()
      .WithMessage("El Id del rol no puede estar vacío.")
      .MustAsync((role, cancellationToken) => context.Repository<Role>().AnyAsync(row => row.Id == role, cancellationToken))
      .WithMessage("El Id del rol '{PropertyValue}' no es válido.");

    RuleFor(row => row.Credentials)
      .NotEmpty()
      .WithErrorCode("Required")
      .WithMessage("Las credenciales son obligatorias.");

    RuleForEach(row => row.Credentials)
      .MustAsync((credential, cancellationToken) => context.Repository<LoginType>().AnyAsync(row => row.Id == credential.LoginTypeId, cancellationToken))
      .WithErrorCode("Invalid")
      .WithMessage("El tipo de login '{PropertyValue}' no es válido.")
      .MustAsync(async (credential, cancellationToken) =>
      {
        LoginType? loginType = await context.Repository<LoginType>().FirstOrDefaultAsync(row => row.Id == credential.LoginTypeId, cancellationToken);
        if (loginType is null)
          return false;

        return loginType.AuthenticationType == AuthenticationTypes.SingleCredential ||
          !await context.Repository<DomainCredential>().AnyAsync(row => row.UserName == credential.UserName && row.LoginTypeId == credential.LoginTypeId, cancellationToken);
      })
      .WithErrorCode("Invalid")
      .WithMessage("El nombre de usuario '{PropertyValue}' ya está en uso para el tipo de login especificado.")
      .MustAsync(async (credential, cancellationToken) =>
      {
        LoginType? loginType = await context.Repository<LoginType>().FirstOrDefaultAsync(row => row.Id == credential.LoginTypeId, cancellationToken);
        if (loginType is null)
          return false;

        return loginType.AuthenticationType == AuthenticationTypes.DomainCredential || credential.ApplicationId is not null;
      })
      .WithErrorCode("Invalid")
      .WithMessage("Id de aplicación obligatoria")
      .MustAsync(async (credential, cancellationToken) =>
      {
        LoginType? loginType = await context.Repository<LoginType>().FirstOrDefaultAsync(row => row.Id == credential.LoginTypeId, cancellationToken);
        if (loginType is null)
          return false;

        return loginType.AuthenticationType == AuthenticationTypes.DomainCredential || credential.ApplicationId is not null &&
          !await context.Repository<SingleCredential>().AnyAsync(row => row.UserName == credential.UserName && row.AppId == credential.ApplicationId, cancellationToken);
      })
      .WithErrorCode("Invalid")
      .WithMessage("El nombre de usuario '{PropertyValue}' ya está en uso para el tipo de login especificado.");

    RuleFor(row => new { row.DocumentTypeId, row.DocumentNumber })
      .Must(row =>
        row.DocumentTypeId is null && row.DocumentNumber is null ||
        row.DocumentTypeId is not null && row.DocumentNumber is not null
      )
      .WithName("Document")
      .WithErrorCode("Invalid")
      .WithMessage("Si se especifica un tipo de documento, debe especificarse un número de documento y viceversa.");

    RuleFor(row => row.FirstName)
      .NotEmpty()
      .WithErrorCode("Required")
      .WithMessage("El nombre es obligatorio.")
      .MaximumLength(50)
      .WithMessage("El nombre no puede tener más de 50 caracteres.");

    RuleFor(row => row.SecondName)
      .MaximumLength(50)
      .WithMessage("El segundo nombre no puede tener más de 50 caracteres.");

    RuleFor(row => row.FirstLastName)
      .NotEmpty()
      .WithErrorCode("Required")
      .WithMessage("El primer apellido es obligatorio.")
      .MaximumLength(50)
      .WithMessage("El primer apellido no puede tener más de 50 caracteres.");

    RuleFor(row => row.SecondLastName)
      .NotEmpty()
      .WithErrorCode("Required")
      .WithMessage("El segundo apellido es obligatorio.")
      .MaximumLength(50)
      .WithMessage("El segundo apellido no puede tener más de 50 caracteres.");

    RuleFor(row => row.Email)
      .NotEmpty()
      .WithErrorCode("Required")
      .WithMessage("El correo electrónico es obligatorio.")
      .EmailAddress()
      .WithErrorCode("Invalid")
      .WithMessage("El correo electrónico no es válido.")
      .MaximumLength(100)
      .WithMessage("El correo electrónico no puede tener más de 100 caracteres.");

    RuleFor(row => row.PhoneNumber)
      .Must(phone => phone is null || DomainRegularExpressions.PhoneNumber.IsMatch(phone))
      .WithErrorCode("Invalid")
      .WithMessage("El número de teléfono no es válido.");

    RuleFor(row => row.Address)
      .MaximumLength(200)
      .WithMessage("La dirección no puede tener más de 200 caracteres.");
  }
}
