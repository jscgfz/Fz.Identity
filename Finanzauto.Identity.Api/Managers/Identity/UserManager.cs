using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Abstractions.Managers.Identity;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Features.V2.Users.Commands.CreateUser;
using Finanzauto.Identity.Api.Features.V2.Users.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Managers.Identity;

public sealed class UserManager(IServiceProvider provider) : IUserManager
{
  private readonly IUnitOfWork _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
  private readonly IDbContext _context = provider.GetRequiredService<IDbContext>();
  private readonly IRoleManager _role = provider.GetRequiredService<IRoleManager>();
  private readonly ICredentialManager _credential = provider.GetRequiredService<ICredentialManager>();
  private readonly IAppManager _app = provider.GetRequiredService<IAppManager>();

  public async Task<Result<CreatedUserDto>> CreateUser(CreateUserCommand cmd, CancellationToken cancellationToken)
  {
    if (await _context.Repository<User>().AnyAsync(row =>
      !string.IsNullOrEmpty(cmd.DocumentNumber) && row.DocumentNumber == cmd.DocumentNumber, cancellationToken))
      return Result.Failure<CreatedUserDto>(
        StatusCodes.Status409Conflict,
        new Error("User.AlreadyExists", "El número de documento ya está registrado")
      );

    User user = new()
    {
      DocumentTypeId = cmd.DocumentTypeId,
      DocumentNumber = cmd.DocumentNumber,
      FirstName = cmd.FirstName,
      SecondName = cmd.SecondName,
      FirstLastName = cmd.FirstLastName,
      SecondLastName = cmd.SecondLastName
    };

    _context.Add(user);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    ContactInfo contactInfo = new()
    {
      UserId = user.Id,
      Email = cmd.Email,
      PhoneNumber = cmd.PhoneNumber,
      Address = cmd.Address
    };

    _context.Add(contactInfo);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return await Result.Success(user.Id)
      .Bind(result => _role.Configure(new(result, cmd.RoleIds, null), cancellationToken))
      .Bind(result => _credential.Registry(user.Id, cmd.Credentials, cancellationToken))
      .Bind(result => _app.UserInfo(user.Id, cancellationToken))
      .Map(result => new CreatedUserDto(
        user.Id,
        user.DocumentTypeId,
        user.DocumentNumber,
        user.FirstName,
        user.SecondName,
        user.FirstLastName,
        user.SecondLastName,
        contactInfo.Email,
        contactInfo.PhoneNumber,
        contactInfo.Address,
        result
      ));
  }
}
