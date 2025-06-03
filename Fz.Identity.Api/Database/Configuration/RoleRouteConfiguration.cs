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
        new() { RouteId = 14, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 15, RoleId = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d") },
        new() { RouteId = 16, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 17, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 18, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 19, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 20, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 21, RoleId = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120") },
        new() { RouteId = 22, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 23, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 24, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 25, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 26, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 27, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 28, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 22, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 23, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 24, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 25, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 26, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 27, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 28, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 40, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 40, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 45, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 45, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 46, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
        new() { RouteId = 46, RoleId = Guid.Parse("07D4316E-4834-48FD-8AFD-A96524C615ED") },
        new() { RouteId = 51, RoleId = Guid.Parse("8149C0B3-18DB-4C79-8DF3-81300B7C5CFB") },
      ]);
  }
}
