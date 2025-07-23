using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Result;
using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Database.Specifications;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Finanzauto.Identity.Api.Domain.Entities.HigherOrder;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace Finanzauto.Identity.Api.Configuration.Authentication;

public sealed class PolicyBuilderFactory
{
  private PolicyBuilderFactory() { }
  private IEnumerable<string>? _claims;
  private bool _isRoot = false;

  public static PolicyBuilderFactory Empty => new();

  public static Action<AuthorizationPolicyBuilder> HigherOrderEndpoint => policyBuilder =>
  {
    policyBuilder.RequireAssertion(async context =>
    {
      if (context.Resource is HttpContext http)
      {
        IReadOnlyDbContext db = http.RequestServices.GetRequiredService<IReadOnlyDbContext>();
        IHashManager hash = http.RequestServices.GetRequiredService<IHashManager>();
        IEnumerable<object>? metadata = http.GetEndpoint()?.Metadata;
        if (metadata is null)
        {
          await WrtiteProblem(
            http,
            Result.Failure(StatusCodes.Status403Forbidden, new Error("Origin.NotFound", "No se logro encontrar el origen"))
          );
          return false;
        }
        string? route = metadata.OfType<IRouteDiagnosticsMetadata>().Select(r => r.Route).FirstOrDefault();
        string method = http.Request.Method.ToUpperInvariant();
        HigherOrderEndpoint? endpoint = await db.Repository<HigherOrderEndpoint>()
          .FirstOrDefaultAsync(row => row.Method == method && row.Route == route, http.RequestAborted);
        if (endpoint is null)
        {
          await WrtiteProblem(
            http,
            Result.Failure(StatusCodes.Status403Forbidden, new Error("Endpoint.NotConfigured", "endpoint no cofigurado para el origen"))
          );
          return false;
        }
        if (endpoint.RequiresSecondAuthLayer && !(http.User.Identity?.IsAuthenticated ?? false))
        {
          await WrtiteProblem(
            http,
            Result.Failure(StatusCodes.Status403Forbidden, new Error("User.NotAuthenticated", "Usuario no autenticado"))
          );
          return false;
        }
        if (endpoint.RequiresThirdAuthLayer)
        {
          if(!http.Request.Headers.TryGetValue(ApplicationHeaders.XSignature256, out StringValues signature) || string.IsNullOrWhiteSpace(signature))
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, new Error("Signature.NotFound", "Firma no encontrada"))
            );
            return false;
          }
          IEnumerable<HigherOrderKey> keys = await db.Repository<HigherOrderKey>()
            .Where(row => row.AllowedEndpoints.Any(origin => origin.EndpointId == endpoint.Id))
            .ToListAsync(http.RequestAborted);

          if (!keys.Any())
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, new Error("Key.NotFound", "No se encontraron llaves para el endpoint"))
            );
            return false;
          }

          byte[] hashComparison = Convert.FromBase64String(signature!);
          using StreamReader reader = new(http.Request.Body, leaveOpen: true);
          string body = await reader.ReadToEndAsync();

          IEnumerable<Result<HigherOrderKey>> responses = await Task
            .WhenAll(
              keys.Select(k => 
                hash.ValidateHash(new(body, hashComparison, k.SignatureKey), http.RequestAborted)
                .Map(result => k)
              )
            );

          if(responses.All(r => r.IsFailure))
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, new Error("Signature.Invalid", "Firma no valida"))
            );
            return false;
          }
        }
        return true;
      }
      return false;
    });
  };

  public PolicyBuilderFactory ValidateClaims(params IEnumerable<string> claims)
  {
    _claims ??= [];
    _claims = _claims.Concat(claims).Distinct();
    return this;
  }

  public PolicyBuilderFactory ValidateSuperUser()
  {
    _isRoot = true;
    return this;
  }

  public Action<AuthorizationPolicyBuilder> Build()
  {
    return policyBuilder =>
    {
      policyBuilder.RequireAuthenticatedUser();
      policyBuilder.RequireAssertion(async context =>
      {
        if (context.Resource is HttpContext http)
        {
          IReadOnlyDbContext db = http.RequestServices.GetRequiredService<IReadOnlyDbContext>();
          Guid? tokenId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) is string id && Guid.TryParse(id, out var guid) ? guid : null;
          if (tokenId is null)
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, new Error("TokenId.NotFound", "No se encontró el idenitificador del token"))
            );
            return false;
          }
          string? tokenType = context.User.FindFirstValue(ClaimTypes.GroupSid);
          if (tokenType is null)
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, new Error("TokenType.NotFound", "No se encontró el tipo de token"))
            );
            return false;
          }
          IEnumerable<Guid> roles = tokenType == TokenGroupSidTypes.User ? context.User
            .FindAll(ClaimTypes.Role)
            .Select(role => Guid.TryParse(role.Value, out var guid) ? guid : Guid.Empty)
            .Where(guid => guid != Guid.Empty) : [];

          IEnumerable<string> claims = tokenType switch
          {
            TokenGroupSidTypes.ApiKey => await ClaimsSpecifications.ByApiKey(tokenId.Value)
              .Apply(db.Repository<ApiKeyClaim>())
              .ToListAsync(http.RequestAborted),
            TokenGroupSidTypes.User => await ClaimsSpecifications.ByRoles(roles)
              .Apply(db.Repository<RoleClaim>())
              .ToListAsync(http.RequestAborted),
              _ => []
          };

          if (_claims is not null && _claims.Any() && !_claims.All(c => claims.Contains(c)))
          {
            await WrtiteProblem(
              http,
              Result.Failure(StatusCodes.Status403Forbidden, [new Error("Claims.NotFound", "Claims no encontrados"), .. _claims.Where(c => !claims.Contains(c)).Select(c => new Error("Claims.Details", c))])
            );
            return false;
          }

          if (_isRoot)
          {
            bool grantAccess = tokenType switch
            {
              TokenGroupSidTypes.ApiKey => await db.Repository<ApiKey>().AnyAsync(row => row.IsRoot && row.Id == tokenId, http.RequestAborted),
              TokenGroupSidTypes.User => await db.Repository<Role>().AnyAsync(row => row.IsRoot && roles.Contains(row.Id), http.RequestAborted),
              _ => false
            };
            if (!grantAccess)
            {
              await WrtiteProblem(
                http,
                Result.Failure(StatusCodes.Status403Forbidden, new Error("User.Forbiben", "Acceso solo a super usuarios"))
              );
              return grantAccess;
            }
          }

          return true;
        }
        return false;
      });
    };
  }

  private static async Task WrtiteProblem(HttpContext http, Result<Unit> result)
  {
    ProblemDetails problem = new()
    {
      Detail = result.GetStatus() switch
      {
        400 => "Status Code 400 - Bad Request",
        401 => "Status Code 401 - Unauthorized",
        402 => "Status Code 402 - Payment Required",
        403 => "Status Code 403 - Forbidden",
        404 => "Status Code 404 - NotFound",
        405 => "Status Code 405 - Method Not Allowed",
        406 => "Status Code 406 - Not Acceptable",
        407 => "Status Code 407 - Proxy Authentication Required",
        408 => "Status Code 408 - Request Timeout",
        409 => "Status Code 409 - Conflict",
        410 => "Status Code 410 - Gone",
        411 => "Status Code 411 - Length Required",
        412 => "Status Code 412 - Precondition Failed",
        413 => "Status Code 413 - Payload Too Large",
        414 => "Status Code 414 - Uri Too Long",
        415 => "Status Code 415 - Unsupported Media Type",
        416 => "Status Code 416 - Range Not Satisfiable",
        417 => "Status Code 417 - Expectation Failed",
        426 => "Status Code 426 - Upgrade Required",
        500 => "Status Code 500 - Internal Server Error",
        501 => "Status Code 501 - Not Implemented",
        502 => "Status Code 502 - Bad Gateway",
        503 => "Status Code 503 - Service Unavailable",
        504 => "Status Code 504 - Gateway Timeout",
        505 => "Status Code 505 - Http Version Not supported",
        _ => throw new NotImplementedException(),
      },
      Status = result.GetStatus(),
      Type = result.GetStatus() switch
      {
        400 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
        401 => "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
        402 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2",
        403 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3",
        404 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
        405 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5",
        406 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6",
        407 => "https://datatracker.ietf.org/doc/html/rfc7235#section-3.2",
        408 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.7",
        409 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
        410 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9",
        411 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.10",
        412 => "https://datatracker.ietf.org/doc/html/rfc7232#section-4.2",
        413 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11",
        414 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.12",
        415 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13",
        416 => "https://datatracker.ietf.org/doc/html/rfc7233#section-4.4",
        417 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.14",
        426 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.15",
        500 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
        501 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2",
        502 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.3",
        503 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4",
        504 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5",
        505 => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.6",
        _ => throw new NotImplementedException(),
      },
      Title = result.GetStatus() switch
      {
        400 => "Bad Request",
        401 => "Unauthorized",
        402 => "Payment Required",
        403 => "Forbidden",
        404 => "NotFound",
        405 => "Method Not Allowed",
        406 => "Not Acceptable",
        407 => "Proxy Authentication Required",
        408 => "Request Timeout",
        409 => "Conflict",
        410 => "Gone",
        411 => "Length Required",
        412 => "Precondition Failed",
        413 => "Payload Too Large",
        414 => "Uri Too Long",
        415 => "Unsupported Media Type",
        416 => "Range Not Satisfiable",
        417 => "Expectation Failed",
        426 => "Upgrade Required",
        500 => "Internal Server Error",
        501 => "Not Implemented",
        502 => "Bad Gateway",
        503 => "Service Unavailable",
        504 => "Gateway Timeout",
        505 => "Http Version Not supported",
        _ => throw new NotImplementedException(),
      },
      Extensions = new Dictionary<string, object?>
      {
        ["errors"] = (from e in result.Erros
                      where e.Code != null
                      group e by e.Code).ToDictionary((IGrouping<string, Error> g) => g.Key, (IGrouping<string, Error> g) => g.Select((Error i) => i.Description))
      }
    };
    if(http.RequestServices.GetRequiredService<IHttpContextAccessor>().HttpContext is HttpContext context)
    {
      context.Response.StatusCode = result.GetStatus();
      await context.Response.WriteAsJsonAsync(problem, http.RequestAborted);
    }
  }
}
