using Finanzauto.Core.Caching.Memory.Extensions;
using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;
using Finanzauto.Core.Persistence.SqlServer.Extensions;
using Finanzauto.Core.Result.Extensions.Behaviors;
using Finanzauto.Core.Result.Extensions.Extensions;
using Finanzauto.Core.Web.Endpoints.Extensions;
using Finanzauto.Identity.Api.Abstractions.Managers;
using Finanzauto.Identity.Api.Abstractions.Managers.Authentication;
using Finanzauto.Identity.Api.Abstractions.Managers.Identity;
using Finanzauto.Identity.Api.Behaviors;
using Finanzauto.Identity.Api.Configuration.Authentication;
using Finanzauto.Identity.Api.Database.DbContexts;
using Finanzauto.Identity.Api.Database.Managers;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Managers;
using Finanzauto.Identity.Api.Managers.Authentication;
using Finanzauto.Identity.Api.Managers.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Finanzauto.Identity.Api.Extensions;

public static class DependencyInjectionExtensions
{
  public static WebApplicationBuilder WithIdentity(this WebApplicationBuilder builder)
    => builder
      .WithIdentityStore()
      .WithMemoryCache()
      .WithManagers()
      .WithCqrs()
      .WithResultProblemDetails()
      .WithApplicationCors()
      .WithApplicationApiExplorer()
      .WithApplicationApiVersioning(null)
      .WithOpenApiDoc("v1", options =>
      {
        options.AddDocumentTransformer((doc, context, cancellationToken) =>
        {
          Dictionary<string, OpenApiSecurityScheme> reqs = new()
          {
            {
              "Json Web Token",
              new()
              {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Description = "Token-based authentication and authorization",
                Name = "Bearer",
                Scheme = "Bearer"
              }
            },
            {
              "Api Key",
              new()
              {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Description = "ApiKey-based authentication and authorization",
                Name = "x-api-key",
                Scheme = "ApiKey"
              }
            }
          };
          doc.Components ??= new();
          doc.Components.SecuritySchemes = reqs;
          foreach (string requirement in reqs.Keys)
            doc.SecurityRequirements.Add(new() { [new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = requirement, Type = ReferenceType.SecurityScheme } }] = [] });
          return Task.CompletedTask;
        });
      })
      .WithOpenApiDoc("v2", options =>
      {
        options.AddDocumentTransformer((doc, context, cancellationToken) =>
        {
          Dictionary<string, OpenApiSecurityScheme> reqs = new()
          {
            {
              "Json Web Token",
              new()
              {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Description = "Token-based authentication and authorization",
                Name = "Bearer",
                Scheme = "Bearer"
              }
            },
            {
              "Api Key",
              new()
              {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Description = "ApiKey-based authentication and authorization",
                Name = ApplicationHeaders.XApiKey,
                Scheme = "ApiKey"
              }
            }
          };
          doc.Components ??= new();
          doc.Components.SecuritySchemes = reqs;
          foreach (string requirement in reqs.Keys)
            doc.SecurityRequirements.Add(new() { [new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = requirement, Type = ReferenceType.SecurityScheme } }] = [] });
          return Task.CompletedTask;
        });
      })
      .WithConfigurationFromContext<ReadOnlyIdentityContext>(TimeSpan.FromMinutes(1))
      .WithApiAuth()
    ;

  private static WebApplicationBuilder WithIdentityStore(this WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<IdentityContext>((provider, options) =>
    {
      options.UseSqlServer(
        builder.Configuration.GetConnectionString(nameof(IdentityContext)),
        sql =>
        {
          sql.MigrationsHistoryTable("Migrations", IdentitySchemas.Configuration);
          sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
          sql.MigrationsAssembly(Assembly.GetExecutingAssembly());
        }
      );
      options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
      options.EnableSensitiveDataLogging();
      options.EnableDetailedErrors();
      options.AddDomainInterceptors(provider);
    });

    builder.Services.AddDbContext<ReadOnlyIdentityContext>((provider, options) =>
    {
      options.UseSqlServer(
        builder.Configuration.GetConnectionString(nameof(IdentityContext)),
        sql =>
        {
          sql.MigrationsHistoryTable("Migrations", IdentitySchemas.Configuration);
          sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
          sql.MigrationsAssembly(Assembly.GetExecutingAssembly());
          sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
        }
      );
      options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
      options.EnableSensitiveDataLogging();
      options.EnableDetailedErrors();
      options.AddDomainInterceptors(provider);
    });

    builder
      .Services
      .AddScoped<IReadOnlyDbContext>(provider => provider.GetRequiredService<ReadOnlyIdentityContext>())
      .AddScoped<IDbContext>(provider => provider.GetRequiredService<IdentityContext>())
      .AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<IdentityContext>())
      .AddSingleton<IContextControlFieldsManager<Guid>, ApplicationControlFieldsManager>();

    return builder
      .WithDomainInterceptors<Guid>();
  }

  private static WebApplicationBuilder WithManagers(this WebApplicationBuilder builder)
  {
    IEnumerable<ServiceDescriptor> descriptors = [
      ServiceDescriptor.Transient<ISignatureKeyManager, SignatureKeyManager>(),
      ServiceDescriptor.Transient<IHashManager, HashManager>(),
      ServiceDescriptor.Singleton<IAppConfigurationManager, AppConfigurationManager>(),
      ServiceDescriptor.Scoped<ICredentialResolverManager, CredentialResolverManager>(),
      ServiceDescriptor.Scoped<ITokenProviderManager, TokenProviderManager>(),
      ServiceDescriptor.Scoped<IUserManager, UserManager>(),
      ServiceDescriptor.Scoped<IRoleManager, RoleManager>(),
      ServiceDescriptor.Scoped<ICredentialManager, CredentialManager>(),
      ServiceDescriptor.Scoped<IAppManager, AppManager>(),
    ];

    builder.Services.TryAddEnumerable(descriptors);
    return builder;
  }

  private static WebApplicationBuilder WithCqrs(this WebApplicationBuilder builder)
  {
    IEnumerable<Assembly> assemblies = [Assembly.GetExecutingAssembly()];
    builder.Services.AddValidatorsFromAssemblies(assemblies);
    return builder.WithResultExtensions(options =>
    {
      options.RegisterServicesFromAssemblies(assemblies.ToArray());
      options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
      options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(InternalCommandTransactionsBehavior<,>));
    });
  }

  private static WebApplicationBuilder WithApiAuth(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer();
    builder.Services.ConfigureOptions<JwtOptionsConfigurer>();
    builder
      .Services
      .AddAuthorization();

    return builder;
  }
}
