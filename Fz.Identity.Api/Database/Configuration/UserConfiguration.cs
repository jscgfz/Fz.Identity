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
    builder.HasData([
      new User
      {
        Id = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        Name = "Jhon Sebastian",
        IdentificationNumber = "1030692232",
        Username = "jhon.cubillos",
        Surname = "Cubillos Gonzalez",
        PrincipalPhoneNumber = "3239336050",
        PrincipalEmail = "jhon.cubillos@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
        Name = "Darcy",
        IdentificationNumber = "0000000000",
        Username = "darcy.novoa",
        Surname = "Novoa",
        PrincipalPhoneNumber = "0000000000",
        PrincipalEmail = "darcy.novoa@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"),
        Name = "Jesus",
        IdentificationNumber = "0000000001",
        Username = "jesus.perez",
        Surname = "Perez",
        PrincipalPhoneNumber = "0000000001",
        PrincipalEmail = "jesus.perez@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
        Name = "Elizabeth",
        IdentificationNumber = "0000000002",
        Username = "elizabeth.gamba",
        Surname = "Gamba",
        PrincipalPhoneNumber = "0000000002",
        PrincipalEmail = "elizabeth.gamba@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
        Name = "Jose",
        IdentificationNumber = "0000000003",
        Username = "jose.bernal",
        Surname = "Bernal",
        PrincipalPhoneNumber = "0000000003",
        PrincipalEmail = "jose.bernal@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
        Name = "Johanna Andrea",
        IdentificationNumber = "0000000004",
        Username = "johanna.riano",
        Surname = "Riaño Chaparro",
        PrincipalPhoneNumber = "0000000004",
        PrincipalEmail = "johanna.riano@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
        Name = "Christian David",
        IdentificationNumber = "0000000005",
        Username = "christian.chilatra",
        Surname = "Chilatra Mendez",
        PrincipalPhoneNumber = "3222264771",
        PrincipalEmail = "christian.chilatra@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("aae0504e-8145-461f-a7ab-9f9621e387d6"),
        Name = "Jeymmy Nataly",
        IdentificationNumber = "0000000006",
        Username = "jeymmy.camelo",
        Surname = "Camelo Santa",
        PrincipalPhoneNumber = "0000000006",
        PrincipalEmail = "jeymmy.camelo@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("134ab661-2928-44e8-9e0c-b96d70e8164c"),
        Name = "Carlos",
        IdentificationNumber = "0000000007",
        Username = "carlos.molano",
        Surname = "Molano",
        PrincipalPhoneNumber = "0000000007",
        PrincipalEmail = "carlos.molano@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
        Name = "Laura",
        IdentificationNumber = "0000000008",
        Username = "laura.roa",
        Surname = "Roa",
        PrincipalPhoneNumber = "3222218468",
        PrincipalEmail = "laura.roa@finanzauto.com.co",
      },
      new User
      {
        Id = Guid.Parse("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
        Name = "Monica",
        IdentificationNumber = "0000000009",
        Username = "monica.infante",
        Surname = "Infante",
        PrincipalPhoneNumber = "0000000005",
        PrincipalEmail = "monica.infante@finanzauto.com.co",
      },
    ]);
  }
}
