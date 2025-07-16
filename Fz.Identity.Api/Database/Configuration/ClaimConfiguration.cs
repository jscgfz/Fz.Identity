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
        new Claim { Id = 5, CalimTypeId = 1, Value = "users.view", Description = "Ver usuarios", ActionId = 1, ModuleId = 1 },
        new Claim { Id = 6, CalimTypeId = 1, Value = "users.create", Description = "Crear usuarios", ActionId = 2, ModuleId = 1 },
        new Claim { Id = 7, CalimTypeId = 1, Value = "users.update", Description = "Actualizar usuarios", ActionId = 3, ModuleId = 1},
        new Claim { Id = 8, CalimTypeId = 1, Value = "users.delete", Description = "Eliminar usuarios", ActionId = 4, ModuleId = 1},
        new Claim { Id = 9, CalimTypeId = 1, Value = "users.importExport", Description = "Descargar/Cargar usuarios", ActionId = 5, ModuleId = 1},
        new Claim { Id = 10, CalimTypeId = 1, Value = "users.review", Description = "Aprobar/Negar usuarios", ActionId = 6, ModuleId = 1},
        new Claim { Id = 11, CalimTypeId = 1, Value = "roles.view", Description = "Ver roles", ActionId = 1, ModuleId = 2 },
        new Claim { Id = 12, CalimTypeId = 1, Value = "roles.create", Description = "Crear roles", ActionId = 2, ModuleId = 2 },
        new Claim { Id = 13, CalimTypeId = 1, Value = "roles.update", Description = "Actualizar roles", ActionId = 3, ModuleId = 2 },
        new Claim { Id = 14, CalimTypeId = 1, Value = "roles.delete", Description = "Eliminar roles", ActionId = 4, ModuleId = 2 },
        new Claim { Id = 15, CalimTypeId = 1, Value = "roles.importExport", Description = "Descargar/Cargar roles", ActionId = 5, ModuleId = 2 },
        new Claim { Id = 16, CalimTypeId = 1, Value = "roles.review", Description = "Aprobar/Negar roles", ActionId = 6, ModuleId = 2 },
        new Claim { Id = 17, CalimTypeId = 1, Value = "managements.view", Description = "Ver gestiones", ActionId = 1, ModuleId = 3 },
        new Claim { Id = 18, CalimTypeId = 1, Value = "managements.create", Description = "Crear gestiones", ActionId = 2, ModuleId = 3 },
        new Claim { Id = 19, CalimTypeId = 1, Value = "managements.update", Description = "Actualizar gestiones", ActionId = 3, ModuleId = 3 },
        new Claim { Id = 20, CalimTypeId = 1, Value = "managements.delete", Description = "Eliminar gestiones", ActionId = 4, ModuleId = 3 },
        new Claim { Id = 21, CalimTypeId = 1, Value = "managements.importExport", Description = "Descargar/Cargar gestiones", ActionId = 5, ModuleId = 3 },
        new Claim { Id = 22, CalimTypeId = 1, Value = "managements.review", Description = "Aprobar/Negar gestiones", ActionId = 6, ModuleId = 3 },
        new Claim { Id = 23, CalimTypeId = 1, Value = "requests.view", Description = "Ver solicitudes", ActionId = 1, ModuleId = 4 },
        new Claim { Id = 24, CalimTypeId = 1, Value = "requests.create", Description = "Crear solicitudes", ActionId = 2, ModuleId = 4 },
        new Claim { Id = 25, CalimTypeId = 1, Value = "requests.update", Description = "Actualizar solicitudes", ActionId = 3, ModuleId = 4 },
        new Claim { Id = 26, CalimTypeId = 1, Value = "requests.delete", Description = "Eliminar solicitudes", ActionId = 4, ModuleId = 4 },
        new Claim { Id = 27, CalimTypeId = 1, Value = "requests.importExport", Description = "Descargar/Cargar solicitudes", ActionId = 5, ModuleId = 4 },
        new Claim { Id = 28, CalimTypeId = 1, Value = "requests.review", Description = "Aprobar/Negar solicitudes", ActionId = 6, ModuleId = 4 },
      ]);
  }
}
