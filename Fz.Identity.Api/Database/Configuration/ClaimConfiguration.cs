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
        new Claim { Id = 5, CalimTypeId = 1, Value = "users.view", Description = "Ver usuarios", ActionId = 1, ModuleId = 1 , Order = 1 },
        new Claim { Id = 6, CalimTypeId = 1, Value = "users.create", Description = "Crear usuarios", ActionId = 2, ModuleId = 1, Order = 2 },
        new Claim { Id = 7, CalimTypeId = 1, Value = "users.update", Description = "Actualizar usuarios", ActionId = 3, ModuleId = 1, Order = 3 },
        new Claim { Id = 8, CalimTypeId = 1, Value = "users.delete", Description = "Eliminar usuarios", ActionId = 4, ModuleId = 1, Order = 4 },
        new Claim { Id = 9, CalimTypeId = 1, Value = "users.importExport", Description = "Descargar/Cargar usuarios", ActionId = 5, ModuleId = 1, Order = 5 },
        new Claim { Id = 10, CalimTypeId = 1, Value = "users.review", Description = "Aprobar/Negar usuarios", ActionId = 6, ModuleId = 1, Order = 6 },
        new Claim { Id = 11, CalimTypeId = 1, Value = "roles.view", Description = "Ver roles", ActionId = 1, ModuleId = 2, Order = 1},
        new Claim { Id = 12, CalimTypeId = 1, Value = "roles.create", Description = "Crear roles", ActionId = 2, ModuleId = 2, Order =2 },
        new Claim { Id = 13, CalimTypeId = 1, Value = "roles.update", Description = "Actualizar roles", ActionId = 3, ModuleId = 2 , Order = 3},
        new Claim { Id = 14, CalimTypeId = 1, Value = "roles.delete", Description = "Eliminar roles", ActionId = 4, ModuleId = 2 , Order = 4},
        new Claim { Id = 15, CalimTypeId = 1, Value = "roles.importExport", Description = "Descargar/Cargar roles", ActionId = 5, ModuleId = 2 , Order = 5},
        new Claim { Id = 16, CalimTypeId = 1, Value = "roles.review", Description = "Aprobar/Negar roles", ActionId = 6, ModuleId = 2 , Order = 6},
        new Claim { Id = 17, CalimTypeId = 1, Value = "managements.view", Description = "Ver gestiones", ActionId = 1, ModuleId = 3, Order = 1 },
        new Claim { Id = 18, CalimTypeId = 1, Value = "managements.create", Description = "Crear gestiones", ActionId = 2, ModuleId = 3 , Order = 2},
        new Claim { Id = 19, CalimTypeId = 1, Value = "managements.update", Description = "Actualizar gestiones", ActionId = 3, ModuleId = 3 , Order = 3},
        new Claim { Id = 20, CalimTypeId = 1, Value = "managements.delete", Description = "Eliminar gestiones", ActionId = 4, ModuleId = 3 , Order = 4},
        new Claim { Id = 21, CalimTypeId = 1, Value = "managements.importExport", Description = "Descargar/Cargar gestiones", ActionId = 5, ModuleId = 3 , Order = 5},
        new Claim { Id = 22, CalimTypeId = 1, Value = "managements.review", Description = "Aprobar/Negar gestiones", ActionId = 6, ModuleId = 3 , Order = 6},
        new Claim { Id = 23, CalimTypeId = 1, Value = "requests.view", Description = "Ver solicitudes", ActionId = 1, ModuleId = 4 , Order = 1},
        new Claim { Id = 24, CalimTypeId = 1, Value = "requests.create", Description = "Crear solicitudes", ActionId = 2, ModuleId = 4 , Order = 2},
        new Claim { Id = 25, CalimTypeId = 1, Value = "requests.update", Description = "Actualizar solicitudes", ActionId = 3, ModuleId = 4 , Order = 3},
        new Claim { Id = 26, CalimTypeId = 1, Value = "requests.delete", Description = "Eliminar solicitudes", ActionId = 4, ModuleId = 4 , Order = 4},
        new Claim { Id = 27, CalimTypeId = 1, Value = "requests.importExport", Description = "Descargar/Cargar solicitudes", ActionId = 5, ModuleId = 4 , Order = 5},
        new Claim { Id = 28, CalimTypeId = 1, Value = "requests.review", Description = "Aprobar/Negar solicitudes", ActionId = 6, ModuleId = 4 , Order = 6},
        new Claim { Id = 29, CalimTypeId = 1, Value = "home.main", Description = "Home", ActionId = 1, ModuleId = 5 , Order = 7},
        new Claim { Id = 30, CalimTypeId = 1, Value = "pqrs.main", Description = "Gestión PQRS", ActionId = 1, ModuleId = 6 , Order = 1},
        new Claim { Id = 31, CalimTypeId = 1, Value = "clents.main", Description = "Gestión Clientes", ActionId = 1, ModuleId = 7 , Order = 1},
        new Claim { Id = 32, CalimTypeId = 1, Value = "pqrs.create-vew", Description = "Radicar PQRS - ver", ActionId = 1, ModuleId = 8 , Order = 1},
        new Claim { Id = 33, CalimTypeId = 1, Value = "pqrs.create-create", Description = "Radicar PQRS - crear", ActionId = 2, ModuleId = 8 , Order = 1},
        new Claim { Id = 34, CalimTypeId = 1, Value = "pqrs.create-delete", Description = "Radicar PQRS - eliminar", ActionId = 3, ModuleId = 8 , Order = 1},
        new Claim { Id = 35, CalimTypeId = 1, Value = "pqrs.create-download", Description = "Radicar PQRS - descargar", ActionId = 4, ModuleId = 8 , Order = 1},
        new Claim { Id = 36, CalimTypeId = 1, Value = "pqrs.create-aprove", Description = "Radicar PQRS - aprovar", ActionId = 5, ModuleId = 8 , Order = 1},
        new Claim { Id = 37, CalimTypeId = 1, Value = "client.detail-vew", Description = "Detalle cliente - ver", ActionId = 1, ModuleId = 9 , Order = 1},
        new Claim { Id = 38, CalimTypeId = 1, Value = "client.detail-create", Description = "Detalle cliente - crear", ActionId = 2, ModuleId = 9 , Order = 1},
        new Claim { Id = 39, CalimTypeId = 1, Value = "client.detail-delete", Description = "Detalle cliente - eliminar", ActionId = 3, ModuleId = 9 , Order = 1},
        new Claim { Id = 40, CalimTypeId = 1, Value = "client.detail-download", Description = "Detalle cliente - descargar", ActionId = 4, ModuleId = 9 , Order = 1},
        new Claim { Id = 41, CalimTypeId = 1, Value = "client.detail-aprove", Description = "Detalle cliente - aprovar", ActionId = 5, ModuleId = 9 , Order = 1},
        new Claim { Id = 42, CalimTypeId = 1, Value = "client.bi-vew", Description = "Cliente - información negocio - ver", ActionId = 1, ModuleId = 10 , Order = 1},
        new Claim { Id = 43, CalimTypeId = 1, Value = "client.bi-create", Description = "Cliente - información negocio - crear", ActionId = 2, ModuleId = 10 , Order = 1},
        new Claim { Id = 44, CalimTypeId = 1, Value = "client.bi-delete", Description = "Cliente - información negocio - eliminar", ActionId = 3, ModuleId = 10 , Order = 1},
        new Claim { Id = 45, CalimTypeId = 1, Value = "client.bi-download", Description = "Cliente - información negocio - descargar", ActionId = 4, ModuleId = 10 , Order = 1},
        new Claim { Id = 46, CalimTypeId = 1, Value = "client.bi-aprove", Description = "Cliente - información negocio - aprovar", ActionId = 5, ModuleId = 10 , Order = 1},
        new Claim { Id = 47, CalimTypeId = 1, Value = "client.duh-vew", Description = "Cliente - Histórico actualización de datos - ver", ActionId = 1, ModuleId = 11 , Order = 1},
        new Claim { Id = 48, CalimTypeId = 1, Value = "client.duh-create", Description = "Cliente - Histórico actualización de datos - crear", ActionId = 2, ModuleId = 11 , Order = 1},
        new Claim { Id = 49, CalimTypeId = 1, Value = "client.duh-delete", Description = "Cliente - Histórico actualización de datos - eliminar", ActionId = 3, ModuleId = 11 , Order = 1},
        new Claim { Id = 50, CalimTypeId = 1, Value = "client.duh-download", Description = "Cliente - Histórico actualización de datos - descargar", ActionId = 4, ModuleId = 11 , Order = 1},
        new Claim { Id = 51, CalimTypeId = 1, Value = "client.duh-aprove", Description = "Cliente - Histórico actualización de datos - aprovar", ActionId = 5, ModuleId = 11 , Order = 1},
        new Claim { Id = 52, CalimTypeId = 1, Value = "client.ah-vew", Description = "Cliente - Histórico alfasis - ver", ActionId = 1, ModuleId = 12 , Order = 1},
        new Claim { Id = 53, CalimTypeId = 1, Value = "client.ah-create", Description = "Cliente - Histórico alfasis - crear", ActionId = 2, ModuleId = 12 , Order = 1},
        new Claim { Id = 54, CalimTypeId = 1, Value = "client.ah-delete", Description = "Cliente - Histórico alfasis - eliminar", ActionId = 3, ModuleId = 12 , Order = 1},
        new Claim { Id = 55, CalimTypeId = 1, Value = "client.ah-download", Description = "Cliente - Histórico alfasis - descargar", ActionId = 4, ModuleId = 12 , Order = 1},
        new Claim { Id = 56, CalimTypeId = 1, Value = "client.ah-aprove", Description = "Cliente - Histórico alfasis - aprovar", ActionId = 5, ModuleId = 12 , Order = 1},
        new Claim { Id = 57, CalimTypeId = 1, Value = "client.ci-vew", Description = "Cliente - información de casos - ver", ActionId = 1, ModuleId = 13 , Order = 1},
        new Claim { Id = 58, CalimTypeId = 1, Value = "client.ci-create", Description = "Cliente - información de casos - crear", ActionId = 2, ModuleId = 13 , Order = 1},
        new Claim { Id = 59, CalimTypeId = 1, Value = "client.ci-delete", Description = "Cliente - información de casos - eliminar", ActionId = 3, ModuleId = 13 , Order = 1},
        new Claim { Id = 60, CalimTypeId = 1, Value = "client.ci-download", Description = "Cliente - información de casos - descargar", ActionId = 4, ModuleId = 13 , Order = 1},
        new Claim { Id = 61, CalimTypeId = 1, Value = "client.ci-aprove", Description = "Cliente - información de casos - aprovar", ActionId = 5, ModuleId = 13 , Order = 1},
        new Claim { Id = 62, CalimTypeId = 1, Value = "client.detail-aprove1", Description = "Detalle cliente - aprovar", ActionId = 6, ModuleId = 9 , Order = 1},
        new Claim { Id = 63, CalimTypeId = 1, Value = "client.detail-aprove1", Description = "Detalle cliente - aprovar", ActionId = 6, ModuleId = 9 , Order = 1},
        new Claim { Id = 64, CalimTypeId = 1, Value = "client.bi-aprove1", Description = "Cliente - información negocio - aprovar", ActionId = 6, ModuleId = 10 , Order = 1},
        new Claim { Id = 65, CalimTypeId = 1, Value = "client.duh-aprove1", Description = "Cliente - Histórico actualización de datos - aprovar", ActionId = 6, ModuleId = 11 , Order = 1},
        new Claim { Id = 66, CalimTypeId = 1, Value = "client.ah-aprove1", Description = "Cliente - Histórico alfasis - aprovar", ActionId = 6, ModuleId = 12 , Order = 1},
        new Claim { Id = 67, CalimTypeId = 1, Value = "client.ci-aprove1", Description = "Cliente - información de casos - aprovar", ActionId = 6, ModuleId = 13 , Order = 1},
        new Claim { Id = 68, CalimTypeId = 1, Value = "home.main", Description = "Home", ActionId = 1, ModuleId = 5 , Order = 7},
        new Claim { Id = 69, CalimTypeId = 1, Value = "home.create", Description = "Home", ActionId = 2, ModuleId = 5 , Order = 7},
        new Claim { Id = 70, CalimTypeId = 1, Value = "home.update", Description = "Home", ActionId = 3, ModuleId = 5 , Order = 7},
        new Claim { Id = 71, CalimTypeId = 1, Value = "home.delete", Description = "Home", ActionId = 4, ModuleId = 5 , Order = 7},
        new Claim { Id = 72, CalimTypeId = 1, Value = "home.download", Description = "Home", ActionId = 5, ModuleId = 5 , Order = 7},
        new Claim { Id = 73, CalimTypeId = 1, Value = "home.aprove", Description = "Home", ActionId = 6, ModuleId = 5 , Order = 7},
        new Claim { Id = 74, CalimTypeId = 1, Value = "pqrs.main", Description = "Gestión PQRS", ActionId = 1, ModuleId = 6 , Order = 1},
        new Claim { Id = 75, CalimTypeId = 1, Value = "pqrs.create", Description = "Gestión PQRS", ActionId = 2, ModuleId = 6 , Order = 1},
        new Claim { Id = 76, CalimTypeId = 1, Value = "pqrs.update", Description = "Gestión PQRS", ActionId = 3, ModuleId = 6 , Order = 1},
        new Claim { Id = 77, CalimTypeId = 1, Value = "pqrs.delete", Description = "Gestión PQRS", ActionId = 4, ModuleId = 6 , Order = 1},
        new Claim { Id = 78, CalimTypeId = 1, Value = "pqrs.download", Description = "Gestión PQRS", ActionId = 5, ModuleId = 6 , Order = 1},
        new Claim { Id = 79, CalimTypeId = 1, Value = "pqrs.aprove", Description = "Gestión PQRS", ActionId = 6, ModuleId = 6 , Order = 1},
        new Claim { Id = 80, CalimTypeId = 1, Value = "clents.main", Description = "Gestión Clientes", ActionId = 1, ModuleId = 7 , Order = 1},
        new Claim { Id = 81, CalimTypeId = 1, Value = "clents.create", Description = "Gestión Clientes", ActionId = 2, ModuleId = 7 , Order = 1},
        new Claim { Id = 82, CalimTypeId = 1, Value = "clents.update", Description = "Gestión Clientes", ActionId = 3, ModuleId = 7 , Order = 1},
        new Claim { Id = 83, CalimTypeId = 1, Value = "clents.delete", Description = "Gestión Clientes", ActionId = 4, ModuleId = 7 , Order = 1},
        new Claim { Id = 84, CalimTypeId = 1, Value = "clents.download", Description = "Gestión Clientes", ActionId = 5, ModuleId = 7 , Order = 1},
        new Claim { Id = 85, CalimTypeId = 1, Value = "clents.aprove", Description = "Gestión Clientes", ActionId = 6, ModuleId = 7 , Order = 1},
        new Claim { Id = 86, CalimTypeId = 1, Value = "pqrs.create-aprove1", Description = "Radicar PQRS - aprovar", ActionId = 6, ModuleId = 8 , Order = 1},
      ]);
  }
}
