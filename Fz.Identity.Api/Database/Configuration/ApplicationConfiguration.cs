using Fz.Identity.Api.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
  public void Configure(EntityTypeBuilder<Application> builder)
  {
    builder.ToTable("Applications", IdentityContextSchemas.Configuration);
    builder.Property(row => row.MultDomainEnabled).HasDefaultValue(false);
    builder.HasData([
      new Application { Id = 1, Name = "Atenea Identity", Description = "Central de identidad del grupo atenea" },
      new Application { Id = 2, Name = "Atenea Iris", Description = "Aplicación principal de Atenea" },
      new Application { Id = 3, Name = "Atenea Asisya", Description = "Atenea para Asisya" },
      new Application { Id = 4, Name = "Atenea Promotec", Description = "Atenea para Promotec" },
      new Application { Id = 5, Name = "Atenea Asterisk", Description = "Central de datos de telefonía" },
      new Application { Id = 6, Name = "Oriana", Description = "Sistema de Créditos Vehiculares" },
      new Application { Id = 7, Name = "Finanzaseguros", Description = "Sistema de financiación de seguros" },
      new Application { Id = 8, Name = "Finanzauto Web Admin", Description = "Administrador de credenciales de usuarios de finanzauto web" },
    ]);
  }
}
