using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Finanzauto.Identity.Api.Features.V2.ApiKeys.Dtos;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;
using Finanzauto.Identity.Api.Models.ApiKey;
using Finanzauto.Identity.Api.Models.Authentication;
using Finanzauto.Identity.Api.Models.Managers.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Finanzauto.Identity.Api.Managers.Authentication;

public sealed class TokenProviderManager(IServiceProvider provider) : ITokenProviderManager
{
  private readonly IReadOnlyDbContext _context = provider.GetRequiredService<IReadOnlyDbContext>();
  private readonly IHashManager _hash = provider.GetRequiredService<IHashManager>();
  private readonly IHttpContextAccessor _httpContext = provider.GetRequiredService<IHttpContextAccessor>();

  public async Task<Result<string>> FromApiKey(string apiKey, CancellationToken cancellationToken)
  {
    IEnumerable<ApiKeyAtomicValues> atomicValues = await ApiKeySpecifications.AtomicValues
      .Apply(_context.Repository<ApiKey>())
    .ToListAsync(cancellationToken);

    IEnumerable<Result<ApikeyDetailsDto>> results = await Task.WhenAll(
      atomicValues
        .Select(value => _hash.ValidateHash(
          new HashRequest(apiKey, value.Hash, value.Salt),
          cancellationToken,
          new Error("ApiKey.Invalid", "Api key invalida")
        ).Map(result => new ApikeyDetailsDto(
          value.Id,
          value.Consumer,
          value.CreatedAtUtc,
          new AppDetailsDto(
            value.AppId,
            value.AppName,
            value.AppDescription,
            value.MultiDomainEnabled,
            value.RootApplicationEnabled,
            value.TwoFactorAuthenticationEnabled,
            null
          )
        ))
        )
    );

    if(results.All(v => v.IsFailure))
      return results.First().Map(v => string.Empty);

    ApikeyDetailsDto apiKeyDetails = results.First(v => v.IsSucces).Value;

    IEnumerable<Role> roles = await _context.Repository<Role>()
      .Where(row => row.AppId == apiKeyDetails.App.Id)
      .ToListAsync(cancellationToken);

    App? app = await _context.Repository<App>()
      .Include(row => row.Safety)
      .FirstOrDefaultAsync(row => row.Id == apiKeyDetails.App.Id, cancellationToken);

    if (app is null)
      return Result.Failure<string>(StatusCodes.Status404NotFound, new Error("App.NotFound", "La aplicación no existe"));

    IEnumerable<Claim> claims = [
      new(ClaimTypes.NameIdentifier, apiKeyDetails.Id.ToString()),
      new(ClaimTypes.Name, apiKeyDetails.Comsumer),
      ..roles.Select(role => new Claim(ClaimTypes.Role, role.Id.ToString())),
      new(ClaimTypes.PrimaryGroupSid, app.Id.ToString()),
      new(ClaimTypes.GroupSid, TokenGroupSidTypes.ApiKey)
    ];

    SymmetricSecurityKey securityKey = new(app.Safety.SignautreKey);
    SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    DateTime expires = DateTime.UtcNow.Add(app.Safety.ExpirationTime);
    JwtSecurityToken jwt = new(
      issuer: app.Prefix,
      audience: app.Prefix,
      expires: expires,
      signingCredentials: signingCredentials,
      claims: claims
    );

    JwtSecurityTokenHandler handler = new();
    return handler.WriteToken(jwt);
  }

  public async Task<Result<TokenResponseDto>> FromResolution(CredentialResolution credentialResolution, CancellationToken cancellationToken)
  {
    IEnumerable<Role> roles = await _context.Repository<Role>()
      .Where(row =>
        row.AppId == credentialResolution.ApplicationId &&
        row.AsignedUsers.Any(user => user.UserId == credentialResolution.UserId) ||
        (!string.IsNullOrEmpty(row.DomainName) && credentialResolution.DomainRoles.Contains(row.DomainName))
      )
      .ToListAsync(cancellationToken);

    App? app = await _context.Repository<App>()
      .Include(row => row.Safety)
      .FirstOrDefaultAsync(row => row.Id == credentialResolution.ApplicationId, cancellationToken);

    if (app is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status404NotFound, new Error("App.NotFound", "La aplicación no existe"));

    User? user = await _context.Repository<User>()
      .Include(row => row.ContactInfo)
      .FirstOrDefaultAsync(row => row.Id == credentialResolution.UserId, cancellationToken);

    if (user is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status404NotFound, new Error("User.NotFound", "El usuario no existe"));

    IEnumerable<Claim> claims = [
      new(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new(ClaimTypes.Email, user.ContactInfo.Email),
      ..roles.Select(role => new Claim(ClaimTypes.Role, role.Id.ToString())),
      new(ClaimTypes.PrimaryGroupSid, app.Id.ToString()),
      new(ClaimTypes.GroupSid, TokenGroupSidTypes.User)
    ];

    if(!string.IsNullOrEmpty(user.ContactInfo.PhoneNumber))
      claims = claims.Append(new Claim(ClaimTypes.MobilePhone, user.ContactInfo.PhoneNumber));

    SymmetricSecurityKey securityKey = new(app.Safety.SignautreKey);
    SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    DateTime expires = DateTime.UtcNow.Add(app.Safety.ExpirationTime);
    JwtSecurityToken jwt = new(
      issuer: app.Prefix,
      audience: app.Prefix,
      expires: expires,
      signingCredentials: signingCredentials,
      claims: claims
    );

    JwtSecurityTokenHandler handler = new();

    return new TokenResponseDto(
      handler.WriteToken(jwt),
      new UserIdentityDto(
        user.Id,
        user.FirstName,
        user.FirstLastName,
        user.ContactInfo.Email,
        user.ContactInfo.PhoneNumber,
        DateTime.UtcNow,
        expires,
        new(
          app.Id,
          app.ApplicationName,
          roles.Select(role => new RoleIdentityDto(role.Id, role.Name, role.DomainName))
        )
      )
    );
  }

  public async Task<Result<TokenResponseDto>> Refresh(CancellationToken cancellationToken)
  {
    Guid? userId = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) is string userIdString && Guid.TryParse(userIdString, out Guid parsedUserId) ? parsedUserId : null;
    if (userId is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status401Unauthorized, new Error("User.Unauthorized", "El usuario no está autorizado"));
    IEnumerable<Guid> roleIds = _httpContext.HttpContext?.User.FindAll(ClaimTypes.Role).Select(role => Guid.Parse(role.Value)) ?? [];
    if (!roleIds.Any())
      return Result.Failure<TokenResponseDto>(StatusCodes.Status401Unauthorized, new Error("User.Unauthorized", "El usuario no tiene roles asignados"));
    Guid? appId = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.PrimaryGroupSid) is string appIdString && Guid.TryParse(appIdString, out Guid parsedAppId) ? parsedAppId : null;
    if (appId is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status401Unauthorized, new Error("App.Unauthorized", "La aplicación no está autorizada"));

    IEnumerable<Role> roles = await _context.Repository<Role>()
      .Where(row =>
        row.AppId == appId &&
        row.AsignedUsers.Any(user => user.UserId == userId) ||
        (!string.IsNullOrEmpty(row.DomainName) && roleIds.Contains(row.Id))
      )
      .ToListAsync(cancellationToken);

    App? app = await _context.Repository<App>()
      .Include(row => row.Safety)
      .FirstOrDefaultAsync(row => row.Id == appId, cancellationToken);

    if (app is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status404NotFound, new Error("App.NotFound", "La aplicación no existe"));

    User? user = await _context.Repository<User>()
      .Include(row => row.ContactInfo)
      .FirstOrDefaultAsync(row => row.Id == userId, cancellationToken);

    if (user is null)
      return Result.Failure<TokenResponseDto>(StatusCodes.Status404NotFound, new Error("User.NotFound", "El usuario no existe"));

    IEnumerable<Claim> claims = [
      new(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new(ClaimTypes.Email, user.ContactInfo.Email),
      ..roles.Select(role => new Claim(ClaimTypes.Role, role.Id.ToString())),
      new(ClaimTypes.PrimaryGroupSid, app.Id.ToString()),
      new(ClaimTypes.GroupSid, TokenGroupSidTypes.User)
    ];

    if (!string.IsNullOrEmpty(user.ContactInfo.PhoneNumber))
      claims = claims.Append(new Claim(ClaimTypes.MobilePhone, user.ContactInfo.PhoneNumber));

    SymmetricSecurityKey securityKey = new(app.Safety.SignautreKey);
    SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    DateTime expires = DateTime.UtcNow.Add(app.Safety.ExpirationTime);
    JwtSecurityToken jwt = new(
      issuer: app.Prefix,
      audience: app.Prefix,
      expires: expires,
      signingCredentials: signingCredentials,
      claims: claims
    );

    JwtSecurityTokenHandler handler = new();

    return new TokenResponseDto(
      handler.WriteToken(jwt),
      new UserIdentityDto(
        user.Id,
        user.FirstName,
        user.FirstLastName,
        user.ContactInfo.Email,
        user.ContactInfo.PhoneNumber,
        DateTime.UtcNow,
        expires,
        new(
          app.Id,
          app.ApplicationName,
          roles.Select(role => new RoleIdentityDto(role.Id, role.Name, role.DomainName))
        )
      )
    );
  }
}
