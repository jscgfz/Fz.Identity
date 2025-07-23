using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authorization;

public sealed class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
  public void Configure(EntityTypeBuilder<UserClaim> builder)
  {
    builder.ToTable("UserClaims", IdentitySchemas.Authentication);
    builder.HasKey(uc => new { uc.UserId, uc.ClaimValueId, uc.AppId });
    builder.HasOne(uc => uc.User)
      .WithMany(u => u.Claims)
      .HasForeignKey(uc => uc.UserId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(uc => uc.ClaimValue)
      .WithMany(cv => cv.Users)
      .HasForeignKey(uc => uc.ClaimValueId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(uc => uc.App)
      .WithMany(uc => uc.UserClaims)
      .HasForeignKey(uc => uc.AppId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
