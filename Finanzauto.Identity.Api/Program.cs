using Asp.Versioning.Builder;
using Finanzauto.Core.Web.Endpoints.Extensions;
using Finanzauto.Identity.Api.Endpoints.Configuration;
using Finanzauto.Identity.Api.Extensions;
using System.Reflection;

var app = WebApplication
  .CreateBuilder(args)
  .WithIdentity()
  .Build();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

ApiVersionSet set = app
  .NewApiVersionSet()
  .HasApiVersion(new(1))
  .HasApiVersion(new(2))
  .ReportApiVersions()
  .Build();

app
  .MapGroup("/api/v{version:apiVersion}")
  .RequireCors()
  .WithApiVersionSet(set)
  .ProducesProblem(StatusCodes.Status400BadRequest)
  .ProducesProblem(StatusCodes.Status500InternalServerError)
  .MapEnpointModulesFromAssemblies<IIdentityModule>(
    Assembly.GetExecutingAssembly()
  );

app
  .MapOepnApiRference(
    "finanzauto-identity-services",
    "reference",
    app.Configuration.GetSection("OpenApiServers").Get<IEnumerable<string>>()
  );

app.Run();