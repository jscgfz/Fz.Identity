using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Models.Settings.Authentication;
using Finanzauto.Identity.Api.Models.Settings.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class DbConfigurationSectionConfiguration : IEntityTypeConfiguration<DbConfigurationSection>
{
  public void Configure(EntityTypeBuilder<DbConfigurationSection> builder)
  {
    builder.ToTable("AppSettings", IdentitySchemas.Configuration);
    builder.HasData(
      [
        ..OtpSettings.DefaultSettings,
        ..JsonWebTokenSettings.DefaultSettings,
        ..PasswordGenerationSettings.DefaultSettings,
        ..DomainAuthenticationSettings.DefaultSettings
      ]
    );
  }
}
