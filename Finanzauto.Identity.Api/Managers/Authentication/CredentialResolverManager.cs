using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Enums.Authentication;
using Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;
using Finanzauto.Identity.Api.Models.Authentication;
using Finanzauto.Identity.Api.Models.Authentication.Request;
using Finanzauto.Identity.Api.Models.Authentication.Response;
using Finanzauto.Identity.Api.Models.Settings.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Managers.Authentication;

public sealed class CredentialResolverManager(IServiceProvider provider) : ICredentialResolverManager
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();
  private readonly IAppConfigurationManager _appManager = provider.GetRequiredService<IAppConfigurationManager>();
  private readonly IHashManager _hashManager = provider.GetRequiredService<IHashManager>();
  private DomainAuthenticationSettings AuthenticationSettings => _appManager.Get<DomainAuthenticationSettings>();

  public async Task<Result<CredentialResolution>> ResolveCredential(LoginCommand cmd, CancellationToken cancellationToken)
  {
    App? app = await _context.Repository<App>()
      .Where(row => row.Id == cmd.ApplicationId || row.AppIndex == cmd.ApplicationIndex)
      .FirstOrDefaultAsync(cancellationToken);

    if (app is null)
      return Result.Failure<CredentialResolution>(
        StatusCodes.Status404NotFound,
        new Error("Application.NotFound", "La aplicación no existe o no está configurada correctamente")
      );

    IEnumerable<LoginType> loginTypes = await _context.Repository<LoginApp>()
      .Include(row => row.LoginType)
      .Where(row => row.AppId == app.Id)
      .Select(row => row.LoginType)
      .ToListAsync(cancellationToken);

    IEnumerable<int> domainIds = loginTypes
      .Where(row => row.AuthenticationType == AuthenticationTypes.DomainCredential)
      .Select(row => row.Id);

    IEnumerable<DomainCredential> domainCredentials = await _context.Repository<DomainCredential>()
      .Where(row => domainIds.Contains(row.LoginTypeId) && row.User.AsignedRoles.Any(role => role.Role.AppId == app.Id) && row.UserName == cmd.UserName)
      .ToListAsync(cancellationToken);

    if (domainCredentials.Any())
    {
      using HttpClient client = new();
      IEnumerable<Result<CredentialResolution>> results = await Task.WhenAll(
        domainCredentials
        .Join(
          loginTypes,
          credential => credential.LoginTypeId,
          loginType => loginType.Id,
          async (credential, loginType) =>
          {
            HttpResponseMessage response = await client.PostAsJsonAsync(
              $"{AuthenticationSettings.BaseUrl}/ValidaUsuario",
              new LdapAuthenticationRequest(credential.UserName, cmd.Password, loginType.DomainName, loginType.Key),
              cancellationToken
            );

            if (!response.IsSuccessStatusCode)
              return Result.Failure<CredentialResolution>(StatusCodes.Status400BadRequest, new Error("Invalid.Credentials", "Credenciales invalidas"));
            
            LdapAuthenticationResponse? ldapResponse = await response.Content.ReadFromJsonAsync<LdapAuthenticationResponse>(cancellationToken: cancellationToken);
            if(ldapResponse is null)
              return Result.Failure<CredentialResolution>(StatusCodes.Status500InternalServerError, new Error("Response.Null", "Respuesta del servidor LDAP es nula"));

            if(ldapResponse.Message.Code != 0)
              return Result.Failure<CredentialResolution>(StatusCodes.Status400BadRequest, new Error("Ldap.Error", ldapResponse.Message.Description));

            return new CredentialResolution(credential.UserId, app.Id, ldapResponse.Roles.Select(row => row.Role));
          }
        )
      );

      return results.Any(row => row.IsSucces) ? results.First(row => row.IsSucces) : results.First();
    }
    else
    {
      if (!loginTypes.Any(row => row.AuthenticationType == AuthenticationTypes.SingleCredential))
        return Result.Failure<CredentialResolution>(
          StatusCodes.Status404NotFound,
          new Error("Credential.NotFound", "No se encontraron credenciales")
        );

      IEnumerable<SingleCredential> singleCredentials = await _context.Repository<SingleCredential>()
        .Where(row => row.UserName == cmd.UserName && row.AppId == cmd.ApplicationId)
        .ToListAsync(cancellationToken);

      if (!singleCredentials.Any())
        return Result.Failure<CredentialResolution>(
          StatusCodes.Status404NotFound,
          new Error("Credential.NotFound", "No se encontraron credenciales")
        );

      IEnumerable<Result<CredentialResolution>> promises = await Task.WhenAll(
        singleCredentials.Select(credential =>
          _hashManager.ValidateHash(new(cmd.Password, credential.PasswordHash, credential.PasswordSalt), cancellationToken)
            .Map(result => new CredentialResolution(credential.UserId, credential.AppId, []))
        )
      );

      return promises.Any(row => row.IsSucces) ? promises.First(row => row.IsSucces) : promises.First();
    }
  }
}
