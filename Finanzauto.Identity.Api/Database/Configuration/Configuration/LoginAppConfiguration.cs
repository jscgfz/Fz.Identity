using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class LoginAppConfiguration : IEntityTypeConfiguration<LoginApp>
{
  public void Configure(EntityTypeBuilder<LoginApp> builder)
  {
    builder.ToTable("LoginApps", IdentitySchemas.Configuration);
    builder.HasKey(row => new { row.AppId, row.LoginTypeId });
    builder.HasOne(row => row.App)
      .WithMany(row => row.AllowedLogins)
      .HasForeignKey(row => row.AppId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.LoginType)
      .WithMany(row => row.AllowedApps)
      .HasForeignKey(row => row.LoginTypeId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
