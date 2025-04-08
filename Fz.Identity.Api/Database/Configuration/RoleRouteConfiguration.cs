using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleRouteConfiguration : IEntityTypeConfiguration<RoleRoute>
{
  public void Configure(EntityTypeBuilder<RoleRoute> builder)
  {
    builder.ToTable("RoleRoutes", IdentityContextSchemas.Configuration);
    builder.HasKey(row => new { row.RoleId, row.RouteId });
    builder
      .HasOne(row => row.Role)
      .WithMany(row => row.Routes)
      .HasForeignKey(row => row.RoleId)
      .OnDelete(DeleteBehavior.NoAction);
    builder
      .HasOne(row => row.Route)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.RouteId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.ReadClaim)
      .WithMany(row => row.ReadRoutes)
      .HasForeignKey(row => row.ReadClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.CreateClaim)
      .WithMany(row => row.CreateRoutes)
      .HasForeignKey(row => row.CreateClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.EditClaim)
      .WithMany(row => row.EditRoutes)
      .HasForeignKey(row => row.EditClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.StatusClaim)
      .WithMany(row => row.StatusRoutes)
      .HasForeignKey(row => row.StatusClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.DownloadClaim)
      .WithMany(row => row.DownloadRoutes)
      .HasForeignKey(row => row.DownloadClaimId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.SpecialConditionClaim)
      .WithMany(row => row.SpecialConditionRoutes)
      .HasForeignKey(row => row.SpecialConditionClaimId)
      .OnDelete(DeleteBehavior.NoAction);

    builder
      .HasData([
        new() { RouteId = 1, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 2 },
        new() { RouteId = 2, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68") },
        new() { RouteId = 3, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 1 },
        new() { RouteId = 4, RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ReadClaimId = 2, CreateClaimId = 3, EditClaimId = 4 },
      ]);
  }
}
