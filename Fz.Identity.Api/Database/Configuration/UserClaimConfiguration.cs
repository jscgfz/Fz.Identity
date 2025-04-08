using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
  public void Configure(EntityTypeBuilder<UserClaim> builder)
  {
    builder.ToTable("UserClaims", IdentityContextSchemas.Auth);
    builder
      .HasIndex(row => new { row.UserId, row.ClaimId, row.ApplicationId })
      .IsUnique();
    builder
      .HasOne(row => row.User)
      .WithMany(row => row.UserClaims)
      .HasForeignKey(row => row.UserId);
    builder
      .HasOne(row => row.Claim)
      .WithMany(row => row.UserClaims)
      .HasForeignKey(row => row.ClaimId);
    builder
      .HasOne(row => row.Application)
      .WithMany(row => row.UserClaims)
      .HasForeignKey(row => row.ApplicationId);
  }
}
