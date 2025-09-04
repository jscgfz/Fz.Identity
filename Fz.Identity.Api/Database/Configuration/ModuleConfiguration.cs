using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
  public void Configure(EntityTypeBuilder<Module> builder)
  {
    builder
      .ToTable("Modules", IdentityContextSchemas.Configuration);
    builder
      .HasData([
        new Module { Id = 1, Name = "Gestión de usuarios", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 2, Name = "Gestión de roles", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 3, Name = "Histórico de gestiones", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 4, Name = "Solicitudes de edición", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 5, Name = "Home", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 6, Name = "Gestión PQRS", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 7, Name = "Clientes", ApplicationId = 4, Description = string.Empty},
        new Module { Id = 8, Name = "Radicar PQRS", ApplicationId = 4, Description = string.Empty, ParentId = 6},
        new Module { Id = 9, Name = "Detalle Cliente", ApplicationId = 4, Description = string.Empty, ParentId = 7},
        new Module { Id = 10, Name = "Información Negocio", ApplicationId = 4, Description = string.Empty, ParentId = 7},
        new Module { Id = 11, Name = "Histórico actualización de datos", ApplicationId = 4, Description = string.Empty, ParentId = 7},
        new Module { Id = 12, Name = "Histórico alfasis", ApplicationId = 4, Description = string.Empty, ParentId = 7},
        new Module { Id = 13, Name = "Información de casos", ApplicationId = 4, Description = string.Empty, ParentId = 7},
        ]);
  }
}
