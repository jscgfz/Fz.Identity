using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class CredentialTypeConfiguration : IEntityTypeConfiguration<CredentialType>
{
  public void Configure(EntityTypeBuilder<CredentialType> builder)
  {
    builder.ToTable("CredentialTypes", IdentityContextSchemas.Configuration);
    builder.Property(row => row.Name)
      .HasField("_name");
    builder.Ignore(row => row.Type);
    builder.HasData([
      new CredentialType { Id = 1, Type = CredentialTypes.FzDomain, Description = "Ingreso por AD bajo dominio Finanzauto" },
      new CredentialType { Id = 2, Type = CredentialTypes.PtDomain, Description = "Ingreso por AD bajo dominio Promotec" },
      new CredentialType { Id = 3, Type = CredentialTypes.ApiKey, Description = "Ingreso por ApiKey" },
      new CredentialType { Id = 4, Type = CredentialTypes.PassWord, Description = "Ingreso por Usuario y Contaseña" },
      new CredentialType { Id = 5, Type = CredentialTypes.AsDomain, Description = "Ingreso por AD bajo dominio Asisya" },
    ]);
  }
}
