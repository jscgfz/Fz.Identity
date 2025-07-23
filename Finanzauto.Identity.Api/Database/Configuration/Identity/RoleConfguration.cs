using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Identity;

public sealed class RoleConfguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("Roles", IdentitySchemas.Identity);
    builder.HasOne(row => row.App)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.AppId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
