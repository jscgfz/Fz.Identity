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
        new Module { Id = 4, Name = "Soliciitudes de edición", ApplicationId = 4, Description = string.Empty},
        ]);
  }
}
