using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public class ActiveDirectoryRoleConfiguration : IEntityTypeConfiguration<ActiveDirectoryRole>
{
  public void Configure(EntityTypeBuilder<ActiveDirectoryRole> builder)
  {
    builder.ToTable("ActiveDirectoryRoles", IdentityContextSchemas.Auth);

    builder
      .HasData([
        new ActiveDirectoryRole { Id = Guid.Parse("3fee3a4e-6ada-482a-aa70-7aba3d1e3e2c"), ApplicationId = 4, Name = "APT_Coordinador" },
        new ActiveDirectoryRole { Id = Guid.Parse("919163a2-ebd1-4b10-8d84-ba98568cbef7"), ApplicationId = 4, Name = "APT_Asistente" },
        new ActiveDirectoryRole { Id = Guid.Parse("103a9658-d288-4192-adb6-e139993c4121"), ApplicationId = 4, Name = "APT_Analista" },
        new ActiveDirectoryRole { Id = Guid.Parse("d9965f5b-0c20-40c5-94a7-e508f8a88e0a"), ApplicationId = 4, Name = "APT_Area" },
        new ActiveDirectoryRole { Id = Guid.Parse("1635c724-2c22-40b8-80e8-01b5da129dba"), ApplicationId = 4, Name = "APT_TI" },
        new ActiveDirectoryRole { Id = Guid.Parse("1ff15957-dc97-4618-9a60-00ba9058a171"), ApplicationId = 4, Name = "APT_SI" },
        new ActiveDirectoryRole { Id = Guid.Parse("3483abb2-e44d-4851-bab5-19ba06746062"), ApplicationId = 4, Name = "APT_Auditor" },
        new ActiveDirectoryRole { Id = Guid.Parse("a9e40a8e-2420-43de-9abb-fcb4cf327d37"), ApplicationId = 4, Name = "APT_Lider_Calidad" },
        new ActiveDirectoryRole { Id = Guid.Parse("821fb971-75b9-44cf-b703-d4e2442fd614"), ApplicationId = 4, Name = "APT_Analista_Calidad" },
        new ActiveDirectoryRole { Id = Guid.Parse("5b3c8352-3390-4d72-8be6-914548f455cb"), ApplicationId = 4, Name = "APT_Lider_SIAR" },
      ]);
  }
}
