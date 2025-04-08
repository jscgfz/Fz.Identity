using Fz.Core.Cache.Abstractions;
using Fz.Core.Persistence.Abstractions;
using Fz.Core.Result;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Models.Identity;
using Fz.Identity.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Fz.Identity.Api.Services.Identity;

public sealed class IdentityTokenProviderService(IServiceProvider provider) : ITokenProviderService
{
  private readonly IReadOnlyDbContext _context
    = provider.GetRequiredKeyedService<IReadOnlyDbContext>(ContextTypes.Identity);
  private readonly ICacheManager _cacheManager
    = provider.GetRequiredService<ICacheManager>();
  private readonly IConfigurationSection _jwt
    = provider.GetRequiredService<IConfiguration>().GetRequiredSection(nameof(JwtBearerOptions));
  private readonly JsonSerializerOptions _jsonSerializerSettings
    = provider.GetRequiredService<IOptions<JsonOptions>>().Value.SerializerOptions;
  private readonly IHttpContextAccessor _contextAccessor
    = provider.GetRequiredService<IHttpContextAccessor>();
  private readonly IIdentityContextControlFieldsManager _identityManager
    = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

  public async Task<Result<IdentityResponseDto>> GenerateToken(User user, int applicationId)
  {
    Application? app = await _context.Repository<Application>()
      .FirstOrDefaultAsync(row => row.Id == applicationId);

    IEnumerable<Role> roles = await _context.Repository<UserRole>()
      .Include(row => row.Role)
      .Where(row => row.UserId == user.Id && row.Role.ApplicationId == applicationId)
      .Select(row => row.Role)
      .ToListAsync();

    if (app == null)
      return Result.Failure<IdentityResponseDto>(ResultTypes.NotFound, [new Error("Application.NotFound", "Aplicación no encontrada")]);
    
    if(!user.Applications.Any(a => a.ApplicationId == applicationId))
      return Result.Failure<IdentityResponseDto>(ResultTypes.Unauthorized, [new Error("User.Unauthorized", $"Acceso no autorizado a la applicación {app.Name}")]);

    IEnumerable<ClaimStorage> claims = [
      ..roles.Select(row => new ClaimStorage(ClaimTypes.Role, row.Id.ToString())),
      new(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new(ClaimTypes.Email, user.PrincipalEmail),
      new(ClaimTypes.Name, user.Name),
      new(ClaimTypes.Surname, user.Surname),
      new(ClaimTypes.Uri, _contextAccessor.HttpContext?.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? string.Empty),
      new(IdentityClaimTypes.ApplicationId, app.Id.ToString()),
      new(IdentityClaimTypes.ApplicationName, app.Name)
    ];

    IdentityStorage identity = new(claims, app, user, roles);

    await _cacheManager.Set(
      $"session:{app.Id}:{user.Id:N}",
      identity,
      TimeSpan.FromMinutes(_jwt.GetValue<int>("TokenExpirationInMinutes"))
    );

    return GenerateToken(identity);
  }

  public async Task<Result<IdentityResponseDto>> RefreshToken()
  {
    Guid nameIdentifier = _identityManager.CurrentUserId;
    if(nameIdentifier == Guid.Empty)
      return Result.Failure<IdentityResponseDto>(ResultTypes.Unauthorized, [new Error("User.Unauthorized", "Usuario no autorizado")]);
    int? applicationId = _identityManager.ApplicationId;
    if(applicationId == null)
      return Result.Failure<IdentityResponseDto>(ResultTypes.Unauthorized, [new Error("ApplicationId.NotFound", "Identificador de aplicación no encontrado")]);

    IdentityStorage? identity = await _cacheManager.TryGetAsync<IdentityStorage>($"session:{applicationId}:{nameIdentifier:N}");
    if (identity == null)
      return Result.Failure<IdentityResponseDto>(ResultTypes.Unauthorized, [new Error("Session.NotFound", "Sesión no encontrada")]);

    IEnumerable<Role> roles = await _context.Repository<UserRole>()
      .Include(row => row.Role)
      .Where(row => row.UserId == nameIdentifier && row.Role.ApplicationId == applicationId)
      .Select(row => row.Role)
      .ToListAsync();

    identity = identity with { Roles = roles };

    await _cacheManager.Set(
      $"session:{applicationId}:{nameIdentifier:N}",
      identity,
      TimeSpan.FromMinutes(_jwt.GetValue<int>("TokenExpirationInMinutes"))
    );

    return GenerateToken(identity);
  }

  private IdentityResponseDto GenerateToken(IdentityStorage identity)
  {
    byte[] securityKey = _jwt.GetValue<Guid>(nameof(TokenValidationParameters.IssuerSigningKey))!.ToByteArray();
    SymmetricSecurityKey key = new([.. securityKey, .. securityKey]);
    SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
    DateTime expires = DateTime.UtcNow.AddMinutes(_jwt.GetValue<int>("TokenExpirationInMinutes"));
    JwtSecurityToken securityToken = new(
      _jwt.GetValue<string>(nameof(TokenValidationParameters.ValidIssuer)),
      _jwt.GetValue<string>(nameof(TokenValidationParameters.ValidAudience)),
      claims: identity.Claims.Select(c => c.ToClaim()),
      expires: expires,
      signingCredentials: creds
    );
    JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
    return new(
      jwtSecurityTokenHandler.WriteToken(securityToken),
      new IdentityUserDto(
        identity.User.Id,
        identity.User.Name,
        identity.User.Surname,
        identity.User.Username,
        identity.User.PrincipalEmail,
        identity.User.PrincipalEmailConfirmed,
        identity.User.PrincipalPhoneNumber,
        identity.User.PrincipalPhoneNumberConfirmed,
        DateTime.UtcNow,
        expires,
        new(identity.App.Id, identity.App.Name, identity.Roles.Any() ? identity.Roles.Select(r => new RoleDto(r.Id, r.Name, null)) : null)
      )
    );
  }
}
