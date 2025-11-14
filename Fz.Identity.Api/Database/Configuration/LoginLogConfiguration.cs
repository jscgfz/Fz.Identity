using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class LoginLogConfiguration : IEntityTypeConfiguration<LoginLog>
{
  public void Configure(EntityTypeBuilder<LoginLog> builder)
  {
    builder.ToTable("LoginLogs", IdentityContextSchemas.Audit);
    builder
      .HasOne(d => d.UserApplication)
      .WithMany(d => d.Logs)
      .HasForeignKey(d => new { d.UserId, d.ApplicationId })
      .OnDelete(DeleteBehavior.ClientNoAction);
    builder
      .Property(d => d.Location)
      .IsRequired(false);
  }
}
