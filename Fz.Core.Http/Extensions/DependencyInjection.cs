using Fz.Core.Http.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OpenApi;
using Asp.Versioning;
using Scalar.AspNetCore;

namespace Fz.Core.Http.Extensions;

public static class DependencyInjection
{
  public static WebApplicationBuilder WithProblemDetails(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddProblemDetails(options =>
      {
        options.CustomizeProblemDetails = context =>
        {
          context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} - {context.HttpContext.Request.Path}";
          context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
          Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
          context.ProblemDetails.Extensions.TryAdd("requestId", activity?.Id);
          if (context.Exception is Exception ex)
          {
            context.ProblemDetails.Detail = ex.Message;
            context.ProblemDetails.Type = ex.HelpLink;
            context.ProblemDetails.Extensions.TryAdd("source", ex.Source);
            context.ProblemDetails.Extensions.TryAdd("stackTrace", ex.StackTrace);
          }
        };
      });

    return builder;
  }

  public static WebApplicationBuilder WithCors(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .AddCors(options =>
      {
        options
          .AddDefaultPolicy(policy =>
          {
            policy
              .WithOrigins(builder.Configuration.GetSection("AllowedHosts").Get<string>()!)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
          });
      });
    return builder;
  }

  public static WebApplicationBuilder WithEndpointsApiExplorer(this WebApplicationBuilder builder)
  {
    builder
      .Services
      .Configure<JsonOptions>(options =>
      {
        options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull;
        options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.SerializerOptions.MaxDepth = 0;
        options.SerializerOptions.WriteIndented = true;
      })
      .AddHttpContextAccessor()
      .AddEndpointsApiExplorer()
      .AddMvcCore();

    return builder;
  }

  public static WebApplicationBuilder WithOpenApi(this WebApplicationBuilder builder, string documentName, Action<OpenApiOptions>? options = default)
  {
    if (options == null)
      builder.Services.AddOpenApi(documentName);
    else
      builder .Services.AddOpenApi(documentName, options);
    return builder;
  }

  public static WebApplicationBuilder WithApiVersioning(this WebApplicationBuilder builder, Action<ApiVersioningOptions>? options = default)
  {
    builder
      .Services
      .AddApiVersioning(versioning =>
      {
        versioning.ReportApiVersions = true;
        versioning.AssumeDefaultVersionWhenUnspecified = true;
        versioning.DefaultApiVersion = new(1, 0);
        options?.Invoke(versioning);
      })
      .AddApiExplorer(explorer =>
      {
        explorer.GroupNameFormat = "'v'V";
        explorer.SubstituteApiVersionInUrl = true;
      });
    return builder;
  }

  public static WebApplicationBuilder WithEndpointModulesFromAssembly<TEndpoint>(this WebApplicationBuilder builder, Assembly assembly)
    where TEndpoint : IEndpointModule
  {
    IEnumerable<ServiceDescriptor> descriptors = assembly
      .DefinedTypes
      .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(TEndpoint)))
      .Select(type => ServiceDescriptor.Transient(typeof(TEndpoint), type));

    builder.Services.TryAddEnumerable(descriptors);

    return builder;
  }

  public static IEndpointRouteBuilder MapEndpointModules<TEndpoint>(this IEndpointRouteBuilder builder)
    where TEndpoint : IEndpointModule
  {
    IEnumerable<TEndpoint> modules = builder.ServiceProvider.GetServices<TEndpoint>();
    foreach (TEndpoint module in modules)
      module.MapEndpoints(builder);
    return builder;
  }

  public static WebApplication MapOpenApiDocument(
    this WebApplication app,
    string applicationName,
    string? endpointReference = default,
    IEnumerable<string>? servers = default)
  {
    app
      .MapScalarApiReference(endpointReference ?? "reference", options =>
      {
        options.Title = applicationName;
        if (servers != null)
          options.Servers = [.. servers.Select(s => new ScalarServer(s))];
      });
    app.MapOpenApi();
    return app;
  }
}
