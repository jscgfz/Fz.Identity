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
      .HasIndex(row => row.CredentialValue)
      .IsUnique();
    builder
      .Property(row => row.CredentialConfirmed)
      .HasDefaultValue(false);
    builder
      .Property(row => row.TwoFactorEnabled)
      .HasDefaultValue(false);
    builder
      .Property(row => row.CredentialValue)
      .HasConversion(new ValueConverter<JsonElement, string>(v => JsonSerializer.Serialize(v, JsonSerializerOptions.Web), v => JsonSerializer.Deserialize<JsonElement>(v, JsonSerializerOptions.Web)));
    builder
      .HasOne(row => row.User)
      .WithMany(row => row.Credentials)
      .HasForeignKey(row => row.UserId);
    builder
      .HasOne(row => row.CredentialType)
      .WithMany(row => row.Credentials)
      .HasForeignKey(row => row.CredentialTypeId);
    builder.HasData([
      new Credential
      {
        Id = 1,
        UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\": \"jhon.cubillos\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 2,
        UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
        CredentialTypeId = ((int)CredentialTypes.PtDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\": \"JCubillos\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 3,
        UserId = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"christian.chilatra\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 4,
        UserId = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"jesus.perez\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 5,
        UserId = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"laura.roa\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 6,
        UserId = Guid.Parse("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"jose.bernal\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 7,
        UserId = Guid.Parse("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"darcy.novoa\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 8,
        UserId = Guid.Parse("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"elizabeth.gamba\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 9,
        UserId = Guid.Parse("134ab661-2928-44e8-9e0c-b96d70e8164c"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"carlos.molano\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 10,
        UserId = Guid.Parse("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"monica.infante\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 11,
        UserId = Guid.Parse("aae0504e-8145-461f-a7ab-9f9621e387d6"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"jeymmy.camelo\"}", JsonSerializerOptions.Web),
      },
      new Credential
      {
        Id = 12,
        UserId = Guid.Parse("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
        CredentialTypeId = ((int)CredentialTypes.FzDomain),
        CredentialValue = JsonSerializer.Deserialize<JsonElement>("{\"Username\":\"johanna.riano\"}", JsonSerializerOptions.Web),
      },
    ]);
  }
}
