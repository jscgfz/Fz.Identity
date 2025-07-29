using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class AreaConfiguration : IEntityTypeConfiguration<Area>
{
  public void Configure(EntityTypeBuilder<Area> builder)
  {
    builder
      .ToTable("Areas", IdentityContextSchemas.Configuration);
    builder
      .HasData([
        new Area{ Id = 1, Name = "Comercial", Description = string.Empty },
        new Area{ Id = 2, Name = "Operaciones", Description = string.Empty},
        new Area{ Id = 3, Name = "Conciliaciones" , Description = string.Empty},
        new Area{ Id = 4, Name = "Indemnizaciones" , Description = string.Empty},
        new Area{ Id = 5, Name = "Cartera" , Description = string.Empty},
        ]);
  }
}
