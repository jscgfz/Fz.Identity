using Finanzauto.Core.Persistence.SqlServer;
using Finanzauto.Core.Persistence.SqlServer.Conventions;
using Finanzauto.Identity.Api.Database.Configuration.Authentication;
using Finanzauto.Identity.Api.Database.Configuration.Authorization;
using Finanzauto.Identity.Api.Database.Configuration.Claims;
using Finanzauto.Identity.Api.Database.Configuration.Configuration;
using Finanzauto.Identity.Api.Database.Configuration.HigherOrder;
using Finanzauto.Identity.Api.Database.Configuration.Identity;
using Finanzauto.Identity.Api.Database.Conventions;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Identity.Api.Database.DbContexts;

// dotnet ef migrations add [] -p ./Finanzauto.Identity.Api -s ./Finanzauto.Identity.Api -c IdentityContext -o ./Database/Migrations/Identity -v
public sealed class ReadOnlyIdentityContext(DbContextOptions<IdentityContext> options, IServiceProvider provider) : IdentityContext(options, provider) { }
public class IdentityContext(DbContextOptions<IdentityContext> options, IServiceProvider provider) : DatabaseContext(options)
{
  protected override void ConfigureConventions(ModelConfigurationBuilder builder)
  {
    builder.Conventions.Add(_ => new AggregateRootConvention());
    builder.Conventions.Add(_ => new AuditableEntityConvention());
    builder.Conventions.Add(_ => new BaseEntityConvention());
    builder.Conventions.Add(_ => new SoftDeleteableEntityConvention());
    builder.Conventions.Add(_ => new RootEntityConvention());
    builder.Conventions.Add(_ => new SeedContextConvention(provider, "Database", "Seeds", "seeds-identity.json"));
    base.ConfigureConventions(builder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder
      .ApplyConfiguration(new ApiKeyConfiguration())
      .ApplyConfiguration(new DomainCredentialConfiguration())
      .ApplyConfiguration(new SingleCredentialConfiguration())
      .ApplyConfiguration(new UserRoleConfiguration())
      .ApplyConfiguration(new ClaimActionConfiguration())
      .ApplyConfiguration(new ClaimSectionConfiguration())
      .ApplyConfiguration(new ClaimValueConfiguration())
      .ApplyConfiguration(new AppConfiguration())
      .ApplyConfiguration(new AppSafetyConfiguration())
      .ApplyConfiguration(new LoginAppConfiguration())
      .ApplyConfiguration(new LoginTypeConfiguration())
      .ApplyConfiguration(new RouteConfiguration())
      .ApplyConfiguration(new HigherOrderEndpointConfiguration())
      .ApplyConfiguration(new HigherOrderKeyConfiguration())
      .ApplyConfiguration(new HigherOrderEndpointOriginConfiguration())
      .ApplyConfiguration(new ContactInfoConfiguration())
      .ApplyConfiguration(new RoleConfguration())
      .ApplyConfiguration(new UserClaimConfiguration())
      .ApplyConfiguration(new RoleRouteConfiguration())
      .ApplyConfiguration(new RoleClaimConfiguration())
      .ApplyConfiguration(new ApiKeyClaimConfiguration())
      .ApplyConfiguration(new DbConfigurationSectionConfiguration())
      .ApplyConfiguration(new UserConfiguration());
  }
}
