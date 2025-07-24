using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fz.Identity.Api.Abstractions.Persistence;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleConfiguration(IIdentityContextControlFieldsManager manager) : IEntityTypeConfiguration<Role>
{
  private readonly IIdentityContextControlFieldsManager _manager = manager;

  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("Roles", IdentityContextSchemas.Auth);
    builder
      .HasIndex(row => new { row.ApplicationId, row.Name })
      .IsUnique();
    builder
      .HasOne(row => row.Application)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.ApplicationId);
    builder
      .HasData([
        new Role { Id = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ApplicationId = 7, Name = "Comercial" },
        new Role { Id = Guid.Parse("89789f4a-570d-451d-b99b-69127421f1fe"), ApplicationId = 7, Name = "Operaciones" },
        new Role { Id = Guid.Parse("228ee2e2-843e-47cc-98ff-ae78e52340b7"), ApplicationId = 7, Name = "Administrador" },
        new Role { Id = Guid.Parse("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), ApplicationId = 7, Name = "GRC" },
        new Role { Id = Guid.Parse("1e219934-094f-48ee-9360-2ad224160120"), ApplicationId = 8, Name = "Admin Contenido" },
        new Role { Id = Guid.Parse("a4622c30-47a6-468b-a1ca-c2be50ca186d"), ApplicationId = 8, Name = "Admin TI" },
        new Role { Id = Guid.Parse("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), ApplicationId = 4, Name = "Administrador" },
        new Role { Id = Guid.Parse("07d4316e-4834-48fd-8afd-a96524c615ed"), ApplicationId = 4, Name = "Agente" },
        new Role { Id = Guid.Parse("0085e762-9a41-4867-942a-0e1b3f892e3f"), ApplicationId = 9, Name = "Agente" },
        new Role { Id = Guid.Parse("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), ApplicationId = 9, Name = "Administrador" },
        new Role { Id = Guid.Parse("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), ApplicationId = 2, Name = "Agente" },
        new Role { Id = Guid.Parse("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), ApplicationId = 2, Name = "Administrador" },
        new Role { Id = Guid.Parse("d525cf87-3c00-48dc-992d-284d2a12772f"), ApplicationId = 3, Name = "Agente" },
        new Role { Id = Guid.Parse("2513a3ec-519a-437c-9f47-d3ed69b5cd06"), ApplicationId = 3, Name = "Administrador" },
        new Role { Id = Guid.Parse("22526b31-4f44-4775-b5b4-6b07005dda60"), ApplicationId = 3, Name = "Calidad" },
        new Role { Id = Guid.Parse("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), ApplicationId = 4, Name = "S.I" },
        new Role { Id = Guid.Parse("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), ApplicationId = 11, Name = "Asesor" },
        new Role { Id = Guid.Parse("d502d91b-7514-4e87-81e5-173584c7bd4a"), ApplicationId = 11, Name = "Coordinador" },
      ]);
  }
}
