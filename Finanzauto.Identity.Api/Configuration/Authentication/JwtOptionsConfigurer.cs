using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Finanzauto.Identity.Api.Configuration.Authentication;

public sealed class JwtOptionsConfigurer(IServiceScopeFactory scopeFactory) : IConfigureNamedOptions<JwtBearerOptions>
{
  private readonly IServiceProvider _provider = scopeFactory.CreateScope().ServiceProvider ?? throw new ArgumentNullException(nameof(scopeFactory));
  private IReadOnlyDbContext _context => _provider.GetRequiredService<IReadOnlyDbContext>();

  public void Configure(string? name, JwtBearerOptions options)
  {
    options.TokenValidationParameters = new()
    {
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuer = true,
      ValidIssuers = _context.Repository<App>().Select(row => row.Prefix).AsEnumerable(),
      ValidAudiences = _context.Repository<App>().Select(row => row.Prefix).AsEnumerable(),
      ClockSkew = TimeSpan.Zero,
      IssuerSigningKeyResolver = IssuerSigningKeyResolver,
      LogValidationExceptions = true,
      RequireAudience = true,
      RequireExpirationTime = true,
      RequireSignedTokens = true,
      ValidAlgorithms = [SecurityAlgorithms.HmacSha256Signature],
    };
    options.SaveToken = true;
    options.Events = new()
    {
      OnMessageReceived = async context =>
      {
        StringValues accessToken = context.Request.Query[ApplicationHeaders.AccessToken];
        if (!string.IsNullOrWhiteSpace(accessToken))
          context.Token = accessToken;
        StringValues apiKey = context.Request.Query[ApplicationHeaders.ApiKey];
        if (string.IsNullOrWhiteSpace(apiKey))
          apiKey = context.Request.Headers[ApplicationHeaders.XApiKey];
        if (!string.IsNullOrWhiteSpace(apiKey))
        {
          ITokenProviderManager tokenProviderManager = _provider.GetRequiredService<ITokenProviderManager>();
          Result<string> token = await tokenProviderManager.FromApiKey(apiKey!, CancellationToken.None);
          if(token.IsSucces)
            context.Token = token.Value;
        }
      }
    };
  }

  public void Configure(JwtBearerOptions options)
    => Configure(JwtBearerDefaults.AuthenticationScheme, options);

  public IEnumerable<SecurityKey> IssuerSigningKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters)
  {
    Result<Guid> app = RetrieveToken(token);
    if (app.IsFailure)
      return [];
    return _context.Repository<AppSafety>()
      .Where(row => row.AppId == app.Value)
      .Select(row => new SymmetricSecurityKey(row.SignautreKey))
      .AsEnumerable();
  }

  public static Result<Guid> RetrieveToken(string token)
  {
    JwtSecurityTokenHandler handler = new();
    JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);
    Claim? groupSid = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.PrimaryGroupSid);
    if (groupSid is null)
      return Result.Failure<Guid>(StatusCodes.Status400BadRequest, new Error("Token.Invalid", "El token no contiene el identificador de la aplicación"));
    if (!Guid.TryParse(groupSid.Value, out Guid appId))
      return Result.Failure<Guid>(StatusCodes.Status400BadRequest, new Error("Token.Invalid", "El token contiene un identificador de aplicación inválido"));
    return Result.Success(appId);
  }
}
