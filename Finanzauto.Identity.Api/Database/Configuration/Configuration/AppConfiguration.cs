using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class AppConfiguration : IEntityTypeConfiguration<App>
{
  public void Configure(EntityTypeBuilder<App> builder)
  {
    builder.ToTable("Apps", IdentitySchemas.Configuration);
    builder.HasIndex(row => row.ApplicationName).IsUnique();
    builder.HasIndex(row => row.AppIndex).IsUnique();
    builder.Property(row => row.ApplicationName).HasMaxLength(50);
    builder.HasIndex(row => row.Prefix).IsUnique();
    builder.Property(row => row.Prefix).HasMaxLength(8);
    builder.HasIndex(row => row.DomainName).IsUnique();
    builder.Property(row => row.DomainName).HasMaxLength(50);
    builder.Property(row => row.MultiDomainEnabled).HasDefaultValue(false);
    builder.Property(row => row.RootApplicationEnabled).HasDefaultValue(false);
    builder.Property(row => row.TwoFactorEnabled).HasDefaultValue(true);
  }
}
