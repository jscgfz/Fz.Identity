using Asp.Versioning.Builder;
using Fz.Core.Cache.InMemory.Extensions;
using Fz.Core.Http.Extensions;
using Fz.Core.Result.Extensions.Extensions;
using Fz.Identity.Api.Abstractions;
using Fz.Identity.Api.Extensions;
using Fz.Identity.Api.Middlewares;
using System.Reflection;

var app = WebApplication
  .CreateBuilder(args)
  .WithIdentityStore()
  .WithProblemDetails()
  .WithEndpointModulesFromAssembly<IIdentityModule>(Assembly.GetExecutingAssembly())
  .WithClientExternalQueryServices()
  .WithInMemoryCache()
  .WithIdentityOpenApi()
  .WithJsonWebToken()
  .WithResultExtensions(options =>
  {
    options.RegisterServicesFromAssemblies([Assembly.GetExecutingAssembly()]);
  })
  .WithApiVersioning()
  .WithCors()
  .WithEndpointsApiExplorer()
  .Build();

ApiVersionSet set = app.NewApiVersionSet()
  .HasApiVersion(new(1))
  .ReportApiVersions()
  .Build();

app.UseHttpsRedirection();
app.UseCors();
app
  .MapGroup("/api/v{version:apiVersion}")
  .RequireCors()
  .WithApiVersionSet(set)
  .ProducesProblem(StatusCodes.Status500InternalServerError)
  .ProducesProblem(StatusCodes.Status400BadRequest)
  .MapEndpointModules<IIdentityModule>();

app.MapOpenApiDocument(
  "finanzauto-identity",
  servers: app.Configuration.GetSection("ScalarServers").Get<IEnumerable<string>>()
  )
  .UseAuthentication()
  .UseAuthorization();

app.UseMiddleware<AuditMiddleware>();
app.Run();