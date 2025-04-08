using Asp.Versioning.Builder;
using Fz.Core.Cache.InMemory.Extensions;
using Fz.Core.Http.Extensions;
using Fz.Finanzaseguros.Api.Abstractions;
using Fz.Finanzaseguros.Infrastructure.Extensions;
using System.Reflection;

var app = WebApplication
  .CreateBuilder(args)
  .WithProblemDetails()
  .WithEndpointModulesFromAssembly<IInsuranceModule>(Assembly.GetExecutingAssembly())
  .WithInMemoryCache()
  .WithApiVersioning()
  .WithCors()
  .WithEndpointsApiExplorer()
  .WithInfrastructure()
  .Build();

ApiVersionSet set = app
  .NewApiVersionSet()
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
  .MapEndpointModules<IInsuranceModule>();

app.MapOpenApiDocument(
  "finanzauto-finanzaseguros",
  servers: app.Configuration.GetSection("ScalarServers").Get<IEnumerable<string>>()
)
  .UseAuthentication()
  .UseAuthorization();

app.Run();