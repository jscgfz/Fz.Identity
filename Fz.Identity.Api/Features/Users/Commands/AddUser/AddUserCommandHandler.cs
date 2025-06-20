using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Core.Result.Extensions;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Features.Users.Commands.AddUser;

public sealed class AddUserCommandHandler(IServiceProvider provider) : ICommandHandler<AddUserCommand, Result<UserAddedResponseDto>>
{
  private readonly IDbContext _dbContext
    = provider.GetRequiredKeyedService<IDbContext>(ContextTypes.Identity);
  private readonly IUnitOfWork _unitOfWork
    = provider.GetRequiredKeyedService<IUnitOfWork>(ContextTypes.Identity);
  private readonly IAlfrescoService _alfresco
    = provider.GetRequiredService<IAlfrescoService>();

  public async Task<Result<UserAddedResponseDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
  {
    IEnumerable<KeyValuePair<Error, bool>> validations = [
      KeyValuePair.Create(
        new Error("Email.Registered", "El email ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<User>().AnyAsync(row => row.PrincipalEmail == request.Email, cancellationToken)),
      KeyValuePair.Create(
        new Error("Username.Registered", "El username ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<User>().AnyAsync(row => row.Username == request.UserName, cancellationToken)),
      KeyValuePair.Create(
        new Error("PhoneNumber.Registered", "El número de telefono ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<User>().AnyAsync(row => !string.IsNullOrEmpty(request.PhoneNamuber) && row.PrincipalPhoneNumber == request.PhoneNamuber, cancellationToken)),
      KeyValuePair.Create(
        new Error("IdentificationNumber.Registered", "El número de identificación ya se encuentra registrado en la base de datos"),
        await _dbContext.Repository<User>().AnyAsync(row => !string.IsNullOrEmpty(request.IdentificationNumber) && row.IdentificationNumber == request.IdentificationNumber, cancellationToken)),
    ];

    if (validations.Any(row => row.Value))
      return Result.Failure<UserAddedResponseDto>(ResultTypes.BadRequest, validations.Where(row => row.Value).Select(row => row.Key));

    if (request.photoBase64 is not null)
    {
      var alfresoResult = await _alfresco.UploadFile(request.UserName, request.photoBase64);
      if (alfresoResult.IsFailure)
        return Result.ValidationError<UserAddedResponseDto>(alfresoResult.Errors);
    }

    User user = new()
    {
      Name = request.Name,
      Surname = request.Surname,
      Username = request.UserName,
      PrincipalEmail = request.Email,
      PrincipalEmailConfirmed = false,
      IdentificationNumber = request.IdentificationNumber,
      PrincipalPhoneNumber = request.PhoneNamuber,
      PrincipalPhoneNumberConfirmed = false,
      DocumentType = request.DocumentType,
    };

    _dbContext.Add(user);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    if (request.RoleIds is not null)
    {
      List<UserRole> userRoles = new();
      foreach (var roleId in request.RoleIds)
      {
        UserRole userRole = new()
        {
          RoleId = roleId,
          UserId = user.Id,
        };
        userRoles.Add(userRole);
      }
      _dbContext.AddRange(userRoles);
      await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    List<UserApplication> userApplications = new();
    foreach (var applicationId in request.ApplicationIds)
    {
      UserApplication userApplication = new()
      {
        ApplicationId = applicationId,
        UserId = user.Id,
      };
      userApplications.Add(userApplication);
    }

    _dbContext.AddRange(userApplications);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return new UserAddedResponseDto(user.Id, user.Username);
  }
}
