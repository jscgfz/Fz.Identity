using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authorization;

public sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
  public void Configure(EntityTypeBuilder<RoleClaim> builder)
  {
    builder.ToTable("RoleClaims", IdentitySchemas.Authentication);
    builder.HasKey(rc => new { rc.RoleId, rc.ClaimValueId });
    builder.HasOne(rc => rc.Role)
      .WithMany(r => r.Claims)
      .HasForeignKey(rc => rc.RoleId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(rc => rc.ClaimValue)
      .WithMany(rc => rc.Roles)
      .HasForeignKey(rc => rc.ClaimValueId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
