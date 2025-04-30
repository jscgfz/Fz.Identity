using Fz.Core.Http.Extensions;
using Fz.Core.Persistence.Abstractions;
using Fz.Identity.Api.Abstractions.Identity;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database;
using Fz.Identity.Api.Database.Managers;
using Fz.Identity.Api.Services.Identity;
using Fz.Identity.Api.Services.Identity.Settings;
using Fz.Identity.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Fz.Identity.Api.Extensions;

public static class DependencyInjection
{
  public static WebApplicationBuilder WithIdentityOpenApi(this WebApplicationBuilder builder)
    => builder.WithOpenApi("v1", options =>
    {
      options.AddDocumentTransformer((doc, context, cancellationToken) =>
      {
        Dictionary<string, OpenApiSecurityScheme> reqs = new()
      {
        {
          "Authentication",
          new()
          {
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Description = "Token-based authentication and authorization",
            Name = "Bearer",
            Scheme = "Bearer"
          }
        }
      };

        doc.Components ??= new();
        doc.Components.SecuritySchemes = reqs;
        foreach (string requirement in reqs.Keys)
          doc.SecurityRequirements.Add(new() { [new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = requirement, Type = ReferenceType.SecurityScheme } }] = [] });

        return Task.CompletedTask;
      });
    });

  public static WebApplicationBuilder WithJsonWebToken(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        IConfigurationSection jwt = builder.Configuration.GetRequiredSection(nameof(JwtBearerOptions));
        byte[] securityKey = jwt.GetValue<Guid>(nameof(options.TokenValidationParameters.IssuerSigningKey))!.ToByteArray();
        options.TokenValidationParameters = new()
        {
          ValidIssuer = jwt.GetValue<string>(nameof(options.TokenValidationParameters.ValidIssuer)),
          ValidAudience = jwt.GetValue<string>(nameof(options.TokenValidationParameters.ValidAudience)),
          ValidateIssuerSigningKey = jwt.GetValue<bool>(nameof(options.TokenValidationParameters.ValidateIssuerSigningKey)),
          IssuerSigningKey = new SymmetricSecurityKey([.. securityKey, .. securityKey]),
          ValidateIssuer = jwt.GetValue<bool>(nameof(options.TokenValidationParameters.ValidateIssuer)),
          ValidateAudience = jwt.GetValue<bool>(nameof(options.TokenValidationParameters.ValidateAudience)),
          ValidateLifetime = jwt.GetValue<bool>(nameof(options.TokenValidationParameters.ValidateLifetime)),
          RequireExpirationTime = jwt.GetValue<bool>(nameof(options.TokenValidationParameters.RequireExpirationTime)),
          ClockSkew = jwt.GetValue<TimeSpan>(nameof(options.TokenValidationParameters.ClockSkew))
        };

        options.Events = new JwtBearerEvents
        {
          OnMessageReceived = context =>
          {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken))
            {
              context.Token = accessToken;
            }
            return Task.CompletedTask;
          }
        };
      });
    builder
      .Services
      .AddAuthorization();

    return builder;
  }

  public static WebApplicationBuilder WithIdentityStore(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddKeyedScoped<IIdentityContextControlFieldsManager, IdentityContextControlFieldsManager>(ContextTypes.Identity);

    builder
      .Services
      .AddDbContext<IdentityReadOnlyContext>(optionBuilder =>
      {
        optionBuilder.UseSqlServer(
          builder.Configuration.GetConnectionString(nameof(IdentityContext)),
          sql =>
          {
            sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            sql.MigrationsAssembly(Assembly.GetExecutingAssembly());
            sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
          }
        );
        optionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionBuilder.EnableDetailedErrors();
        optionBuilder.EnableSensitiveDataLogging();
      });

    builder
      .Services
      .AddKeyedScoped<IReadOnlyDbContext>(ContextTypes.Identity, (provider, ob) => 
        provider.GetRequiredService<IdentityReadOnlyContext>());

    builder.Services.AddDbContext<IdentityContext>(optionBuilder =>
    {
      optionBuilder.UseSqlServer(
          builder.Configuration.GetConnectionString(nameof(IdentityContext)),
          sql =>
          {
            sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            sql.MigrationsAssembly(Assembly.GetExecutingAssembly());
            sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
          }
        );
      optionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
      optionBuilder.EnableDetailedErrors();
      optionBuilder.EnableSensitiveDataLogging();
    });

    builder
      .Services
      .AddKeyedScoped<IDbContext>(ContextTypes.Identity,
        (provider, ob) => provider.GetRequiredService<IdentityContext>());
    
    builder
      .Services
      .AddKeyedScoped<IUnitOfWork>(ContextTypes.Identity,
        (provider, ob) => provider.GetRequiredService<IdentityContext>());

    builder
      .Services
      .AddKeyedScoped<ICredentialValidatorService, FzCredentialValidatorService>(CredentialTypes.FzDomain);

    builder
      .Services
      .AddOptions<FzCredentialSettings>()
      .BindConfiguration(nameof(FzCredentialSettings))
      .ValidateDataAnnotations()
      .ValidateOnStart();

    builder
      .Services
      .AddKeyedScoped<ITokenProviderService, IdentityTokenProviderService>(ContextTypes.Identity);

    return builder;
  }
}