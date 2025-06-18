using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users", IdentityContextSchemas.Auth);
    builder.HasIndex(row => row.Username).IsUnique();
    builder.HasIndex(row => row.PrincipalEmail).IsUnique();
    builder.HasIndex(row => row.PrincipalPhoneNumber).IsUnique();
    builder.HasIndex(row => row.IdentificationNumber).IsUnique();
    builder.Property(row => row.DocumentType).HasDefaultValue("C");
    builder.HasData([
      new()
      {
        Id = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        Name = "Jhon Sebastian",
        IdentificationNumber = "1030692232",
        Username = "jhon.cubillos",
        Surname = "Cubillos Gonzalez",
        PrincipalPhoneNumber = "3239336050",
        PrincipalEmail = "jhon.cubillos@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
        Name = "Darcy",
        IdentificationNumber = "0000000000",
        Username = "darcy.novoa",
        Surname = "Novoa",
        PrincipalPhoneNumber = "0000000000",
        PrincipalEmail = "darcy.novoa@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"),
        Name = "Jesus",
        IdentificationNumber = "0000000001",
        Username = "jesus.perez",
        Surname = "Perez",
        PrincipalPhoneNumber = "0000000001",
        PrincipalEmail = "jesus.perez@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
        Name = "Elizabeth",
        IdentificationNumber = "0000000002",
        Username = "elizabeth.gamba",
        Surname = "Gamba",
        PrincipalPhoneNumber = "0000000002",
        PrincipalEmail = "elizabeth.gamba@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
        Name = "Jose",
        IdentificationNumber = "0000000003",
        Username = "jose.bernal",
        Surname = "Bernal",
        PrincipalPhoneNumber = "0000000003",
        PrincipalEmail = "jose.bernal@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
        Name = "Johanna Andrea",
        IdentificationNumber = "0000000004",
        Username = "johanna.riano",
        Surname = "Riaño Chaparro",
        PrincipalPhoneNumber = "0000000004",
        PrincipalEmail = "johanna.riano@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
        Name = "Christian David",
        IdentificationNumber = "0000000005",
        Username = "christian.chilatra",
        Surname = "Chilatra Mendez",
        PrincipalPhoneNumber = "3222264771",
        PrincipalEmail = "christian.chilatra@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("aae0504e-8145-461f-a7ab-9f9621e387d6"),
        Name = "Jeymmy Nataly",
        IdentificationNumber = "0000000006",
        Username = "jeymmy.camelo",
        Surname = "Camelo Santa",
        PrincipalPhoneNumber = "0000000006",
        PrincipalEmail = "jeymmy.camelo@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("134ab661-2928-44e8-9e0c-b96d70e8164c"),
        Name = "Carlos",
        IdentificationNumber = "0000000007",
        Username = "carlos.molano",
        Surname = "Molano",
        PrincipalPhoneNumber = "0000000007",
        PrincipalEmail = "carlos.molano@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
        Name = "Laura",
        IdentificationNumber = "0000000008",
        Username = "laura.roa",
        Surname = "Roa",
        PrincipalPhoneNumber = "3222218468",
        PrincipalEmail = "laura.roa@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
        Name = "Monica",
        IdentificationNumber = "0000000009",
        Username = "monica.infante",
        Surname = "Infante",
        PrincipalPhoneNumber = "0000000005",
        PrincipalEmail = "monica.infante@finanzauto.com.co",
      },
      new()
      {
        Id = Guid.Parse("aa79dc95-724d-4eef-9744-7debd5d322a3"),
        Name = "Julieth",
        Surname = "Quiñiones",
        Username = "julieth.quinones",
        PrincipalEmail = "julieth.quinones@asisya.com",
        PrincipalPhoneNumber = "1000000000",
        IdentificationNumber = "1000000000"
      },
      new()
      {
        Id = Guid.Parse("b1c48de3-2e15-4f06-a3c4-be4775936220"),
        Name = "Paula",
        Surname = "Moreno",
        Username = "paula.moreno",
        PrincipalEmail = "paula.moreno@asisya.com",
        PrincipalPhoneNumber = "1000000001",
        IdentificationNumber = "1000000001"
      },
      new()
      {
        Id = Guid.Parse("f291a98b-36da-4651-bdb5-c7f60e20d802"),
        Name = "Oscar",
        Surname = "Vinasco",
        Username = "oscar.vinasco",
        PrincipalEmail = "oscar.vinasco@asisya.com",
        PrincipalPhoneNumber = "1000000002",
        IdentificationNumber = "1000000002"
      },
      new()
      {
        Id = Guid.Parse("56313c74-d9fd-44d3-9668-c8ff502c556d"),
        Name = "Laura",
        Surname = "Rueda",
        Username = "laura.rueda",
        PrincipalEmail = "laura.rueda@asisya.com",
        PrincipalPhoneNumber = "1000000003",
        IdentificationNumber = "1000000003"
      },
      new()
      {
        Id = Guid.Parse("d6b042e8-2476-447e-80b4-a8c2c7b32ace"),
        Name = "Arlein",
        Surname = "Pomar",
        Username = "arlein.pomar",
        PrincipalEmail = "arlein.pomar@asisya.com",
        PrincipalPhoneNumber = "1000000004",
        IdentificationNumber = "1000000004"
      },
      new()
      {
        Id = Guid.Parse("f015f137-5352-48e9-8120-609639131906"),
        Name = "Nicolas",
        Surname = "Rico",
        Username = "nicolas.rico",
        PrincipalEmail = "nicolas.rico@asisya.com",
        PrincipalPhoneNumber = "1000000005",
        IdentificationNumber = "1000000005"
      },
      new()
      {
        Id = Guid.Parse("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"),
        Name = "Astrid",
        Surname = "Meneses",
        Username = "astrid.meneses",
        PrincipalEmail = "astrid.meneses@asisya.com",
        PrincipalPhoneNumber = "1000000006",
        IdentificationNumber = "1000000006"
      },
      new()
      {
        Id = Guid.Parse("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"),
        Name = "Jose Willy Duvan",
        Surname = "Carrillo Carrillo",
        Username = "jose.carrillo",
        PrincipalEmail = "jose.carrillo@asisya.com.co",
        PrincipalPhoneNumber = "1000000007",
        IdentificationNumber = "1000000007"
      },
      new()
      {
        Id = Guid.Parse("9C5A2E53-4182-4743-A36D-CF116AD3B49E"),
        Name = "Cristhian",
        Surname = "López",
        Username = "cristhian.lopez",
        PrincipalEmail = "cristhian.lopez@asisya.com",
        PrincipalPhoneNumber = "1000000027",
        IdentificationNumber = "1000000027"
      },
      new()
      {
        Id = Guid.Parse("5F7B3712-0829-4A4B-A3C5-F38F35E37CA8"),
        Name = "Carol",
        Surname = "Medina",
        Username = "carol.medina",
        PrincipalEmail = "carol.medina@asisya.com",
        PrincipalPhoneNumber = "1000000037",
        IdentificationNumber = "1000000037"
      }
    ]);
  }
}
