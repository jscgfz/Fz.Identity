using Fz.Identity.Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = Fz.Identity.Api.Database.Entities.Action;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class ActionConfiguration : IEntityTypeConfiguration<Action>
{
  public void Configure(EntityTypeBuilder<Action> builder)
  {
    builder
      .ToTable("Actions", IdentityContextSchemas.Configuration);
    builder
      .HasData([
        new Action { Id = 1, Name = "Ver", Description = string.Empty },
        new Action { Id = 2, Name = "Crear", Description = string.Empty },
        new Action { Id = 3, Name = "Modificar" , Description = string.Empty},
        new Action { Id = 4, Name = "Eliminar" , Description = string.Empty},
        new Action { Id = 5, Name = "Descargar/Cargar" , Description = string.Empty},
        new Action { Id = 6, Name = "Aprobar/Negar" , Description = string.Empty},
        ]);
  }
}
