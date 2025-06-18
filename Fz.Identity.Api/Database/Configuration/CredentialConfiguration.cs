using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class CredentialConfiguration : IEntityTypeConfiguration<Credential>
{
  public void Configure(EntityTypeBuilder<Credential> builder)
  {
    builder.ToTable("Credentials", IdentityContextSchemas.Auth);
    builder
      .HasIndex(row => new { row.UserId, row.CredentialTypeId })
      .IsUnique();
    builder
      .HasIndex(row => new { row.CredentialValue, row.CredentialTypeId })
      .IsUnique();
    builder
      .Property(row => row.CredentialConfirmed)
      .HasDefaultValue(false);
    builder
      .Property(row => row.TwoFactorEnabled)
      .HasDefaultValue(false);
    builder
      .HasOne(row => row.User)
      .WithMany(row => row.Credentials)
      .HasForeignKey(row => row.UserId);
    builder
      .HasOne(row => row.CredentialType)
      .WithMany(row => row.Credentials)
      .HasForeignKey(row => row.CredentialTypeId);
    builder.HasData([
      new()
      {
        Id = 1,
        UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "jhon.cubillos",
      },
      new()
      {
        Id = 2,
        UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        CredentialTypeId = ((int)CredentialTypes.PtDomain),
        CredentialValue = "JCubillos",
      },
      new()
      {
        Id = 3,
        UserId = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "christian.chilatra",
      },
      new()
      {
        Id = 4,
        UserId = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "jesus.perez"
      },
      new()
      {
        Id = 5,
        UserId = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "laura.roa"
      },
      new()
      {
        Id = 6,
        UserId = Guid.Parse("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "jose.bernal"
      },
      new()
      {
        Id = 7,
        UserId = Guid.Parse("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "darcy.novoa"
      },
      new()
      {
        Id = 8,
        UserId = Guid.Parse("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "elizabeth.gamba"
      },
      new()
      {
        Id = 9,
        UserId = Guid.Parse("134ab661-2928-44e8-9e0c-b96d70e8164c"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "carlos.molano"
      },
      new()
      {
        Id = 10,
        UserId = Guid.Parse("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "monica.infante"
      },
      new()
      {
        Id = 11,
        UserId = Guid.Parse("aae0504e-8145-461f-a7ab-9f9621e387d6"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "jeymmy.camelo"
      },
      new()
      {
        Id = 12,
        UserId = Guid.Parse("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = "johanna.riano"
      },
      new()
      {
        Id = 13,
        UserId = Guid.Parse("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "jose.carrillo"
      },
      new()
      {
        Id = 14,
        UserId = Guid.Parse("f015f137-5352-48e9-8120-609639131906"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "nicolas.rico"
      },
      new()
      {
        Id = 15,
        UserId = Guid.Parse("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "astrid.meneses"
      },
      new()
      {
        Id = 16,
        UserId = Guid.Parse("d6b042e8-2476-447e-80b4-a8c2c7b32ace"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "arlein.pomar"
      },
      new()
      {
        Id = 17,
        UserId = Guid.Parse("aa79dc95-724d-4eef-9744-7debd5d322a3"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "julieth.quinones"
      },
      new()
      {
        Id = 18,
        UserId = Guid.Parse("56313c74-d9fd-44d3-9668-c8ff502c556d"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "laura.rueda"
      },
      new()
      {
        Id = 19,
        UserId = Guid.Parse("b1c48de3-2e15-4f06-a3c4-be4775936220"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "paula.moreno"
      },
      new()
      {
        Id = 20,
        UserId = Guid.Parse("f291a98b-36da-4651-bdb5-c7f60e20d802"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "oscar.vinasco"
      },
      new()
      {
        Id = 21,
        UserId = Guid.Parse("9C5A2E53-4182-4743-A36D-CF116AD3B49E"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "cristhian.lopez"
      },
      new()
      {
        Id = 22,
        UserId = Guid.Parse("5F7B3712-0829-4A4B-A3C5-F38F35E37CA8"),
        CredentialTypeId = ((int)CredentialTypes.AsDomain),
        CredentialValue = "carol.medina"
      },
    ]);
  }
}
