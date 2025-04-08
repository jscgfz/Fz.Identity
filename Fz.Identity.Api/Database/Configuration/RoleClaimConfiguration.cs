using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
  public void Configure(EntityTypeBuilder<RoleClaim> builder)
  {
    builder.ToTable("RoleClaims", IdentityContextSchemas.Auth);
    builder
      .HasIndex(builder => new { builder.RoleId, builder.ClaimId })
      .IsUnique();
    builder
      .HasOne(builder => builder.Role)
      .WithMany(builder => builder.RoleClaims)
      .HasForeignKey(builder => builder.RoleId);
    builder
      .HasOne(builder => builder.Claim)
      .WithMany(builder => builder.RoleClaims)
      .HasForeignKey(builder => builder.ClaimId);
    builder
      .HasData([
        new RoleClaim { Id = 1, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ClaimId = 1 },
        new RoleClaim { Id = 2, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ClaimId = 2 },
        new RoleClaim { Id = 3, RoleId = Guid.Parse("89789f4a-570d-451d-b99b-69127421f1fe"), ClaimId = 3 },
        new RoleClaim { Id = 4, RoleId = Guid.Parse("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), ClaimId = 3 },
        new RoleClaim { Id = 5, RoleId = Guid.Parse("228ee2e2-843e-47cc-98ff-ae78e52340b7"), ClaimId = 4 },
      ]);
  }
}
