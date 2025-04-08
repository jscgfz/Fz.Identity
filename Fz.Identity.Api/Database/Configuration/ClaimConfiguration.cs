using Fz.Identity.Api.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class ClaimConfiguration : IEntityTypeConfiguration<Claim>
{
  public void Configure(EntityTypeBuilder<Claim> builder)
  {
    builder
      .ToTable("Claims", IdentityContextSchemas.Auth);
    builder
      .HasIndex(row => new { row.CalimTypeId, row.Value })
      .IsUnique();
    builder
      .HasOne(row => row.Parent)
      .WithMany(row => row.Children)
      .HasForeignKey(row => row.ParentId)
      .OnDelete(DeleteBehavior.NoAction);
    builder
      .HasOne(row => row.ClaimType)
      .WithMany(row => row.Claims)
      .HasForeignKey(row => row.CalimTypeId);
    builder
      .HasData([
        new Claim { Id = 1, CalimTypeId = 1, Value = "clients:view", Description = "Ver detalle clientes" },
        new Claim { Id = 2, CalimTypeId = 1, Value = "credits:view", Description = "Ver detalle creditos" },
        new Claim { Id = 3, CalimTypeId = 1, Value = "credits:create", Description = "Radicar creditos creditos" },
        new Claim { Id = 4, CalimTypeId = 1, Value = "credits:update", Description = "Actualizar creditos" },
      ]);
  }
}
