using Fz.Core.Persistence;
using Fz.Core.Persistence.Conventions;
using Fz.Core.Persistence.Interceptors;
using Fz.Identity.Api.Abstractions.Persistence;
using Fz.Identity.Api.Database.Configuration;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database;



// dotnet ef migrations add [] -s ./Fz.Identity.Api -p ./Fz.Identity.Api -c IdentityContext -o Database/Migrations -v
public class IdentityReadOnlyContext(DbContextOptions options, IServiceProvider provider) : IdentityContext(options, provider) { }
public class IdentityContext(DbContextOptions options, IServiceProvider provider) : DatabaseContext(options)
{
  private readonly IIdentityContextControlFieldsManager _manager = provider.GetRequiredKeyedService<IIdentityContextControlFieldsManager>(ContextTypes.Identity);

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(new AuditableEntityInterceptor<IdentityContext, Guid>(_manager));
    optionsBuilder.AddInterceptors(new SoftDeleteableEntityInterceptor<IdentityContext, Guid>(_manager));
    base.OnConfiguring(optionsBuilder);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Conventions.Add(_ => new AuditableEntityConvention());
    configurationBuilder.Conventions.Add(_ => new BaseEntityConvention());
    configurationBuilder.Conventions.Add(_ => new SoftDeleteableEntityConvention());
    base.ConfigureConventions(configurationBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder
      .ApplyConfiguration(new ApplicationConfiguration())
      .ApplyConfiguration(new ClaimConfiguration())
      .ApplyConfiguration(new ClaimTypeConfiguration())
      .ApplyConfiguration(new CredentialConfiguration())
      .ApplyConfiguration(new CredentialTypeConfiguration())
      .ApplyConfiguration(new RoleConfiguration(_manager))
      .ApplyConfiguration(new RoleClaimConfiguration())
      .ApplyConfiguration(new UserConfiguration())
      .ApplyConfiguration(new UserClaimConfiguration())
      .ApplyConfiguration(new AllowedCredentialConfiguration())
      .ApplyConfiguration(new UserAplicationConfiguration())
      .ApplyConfiguration(new RouteConfiguration())
      .ApplyConfiguration(new RoleRouteConfiguration())
      .ApplyConfiguration(new UserRoleConfiguration())
      .ApplyConfiguration(new AuditLogConfiguration())
      .ApplyConfiguration(new ActionConfiguration())
      .ApplyConfiguration(new ModuleConfiguration())
      .ApplyConfiguration(new RequestConfiguration())
      .ApplyConfiguration(new RequestStatusConfiguration())
      .ApplyConfiguration(new CompanyConfiguration());
  }
}
