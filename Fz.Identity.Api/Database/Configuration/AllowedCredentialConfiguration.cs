using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class AllowedCredentialConfiguration : IEntityTypeConfiguration<AllowedCredential>
{
  public void Configure(EntityTypeBuilder<AllowedCredential> builder)
  {
    builder.ToTable("AllowedCredentials", IdentityContextSchemas.Configuration);
    builder.HasKey(row => new { row.CredentialTypeId, row.ApplicationId });
    builder
      .HasOne(row => row.CredentialType)
      .WithMany(row => row.AllowedCredentials)
      .HasForeignKey(row => row.CredentialTypeId);
    builder
      .HasOne(row => row.Application)
      .WithMany(row => row.AllowedCredentials)
      .HasForeignKey(row => row.ApplicationId);
    builder
      .HasData([
        new AllowedCredential { ApplicationId = 1, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 1, CredentialTypeId = 3 },
        new AllowedCredential { ApplicationId = 2, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 3, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 4, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 5, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 5, CredentialTypeId = 3 },
        new AllowedCredential { ApplicationId = 6, CredentialTypeId = 1 },
        new AllowedCredential { ApplicationId = 7, CredentialTypeId = 1 }
      ]);
  }
}
