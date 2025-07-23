using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class AppSafetyConfiguration : IEntityTypeConfiguration<AppSafety>
{
  public void Configure(EntityTypeBuilder<AppSafety> builder)
  {
    builder.ToTable("AppSafety", IdentitySchemas.Configuration);
    builder.HasKey(row => row.AppId);
    builder.HasIndex(row => row.SignautreKey).IsUnique();
    builder.Property(row => row.ExpirationTime).HasDefaultValue(TimeSpan.FromHours(1));
    builder.Property(row => row.ExpirationTime).HasDefaultValue(TimeSpan.FromHours(2));
    builder.HasOne(row => row.App)
      .WithOne(row => row.Safety)
      .HasForeignKey<AppSafety>(row => row.AppId);
  }
}
