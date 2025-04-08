using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
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
        new() { ApplicationId = 1, CredentialTypeId = ((int)CredentialTypes.FzDomain) },
        new() { ApplicationId = 1, CredentialTypeId = ((int)CredentialTypes.PtDomain) },
        new() { ApplicationId = 1, CredentialTypeId = ((int)CredentialTypes.ApiKey) },
        new() { ApplicationId = 1, CredentialTypeId = ((int)CredentialTypes.PassWord) },
        new() { ApplicationId = 1, CredentialTypeId = ((int)CredentialTypes.AsDomain) },
        new() { ApplicationId = 2, CredentialTypeId = ((int)CredentialTypes.FzDomain) },
        new() { ApplicationId = 2, CredentialTypeId = ((int)CredentialTypes.PtDomain) },
        new() { ApplicationId = 2, CredentialTypeId = ((int)CredentialTypes.ApiKey) },
        new() { ApplicationId = 2, CredentialTypeId = ((int)CredentialTypes.PassWord) },
        new() { ApplicationId = 2, CredentialTypeId = ((int)CredentialTypes.AsDomain) },
        new() { ApplicationId = 3, CredentialTypeId = ((int)CredentialTypes.AsDomain) },
        new() { ApplicationId = 4, CredentialTypeId = ((int)CredentialTypes.PtDomain) },
        new() { ApplicationId = 5, CredentialTypeId = ((int)CredentialTypes.FzDomain) },
        new() { ApplicationId = 5, CredentialTypeId = ((int)CredentialTypes.PtDomain) },
        new() { ApplicationId = 5, CredentialTypeId = ((int)CredentialTypes.ApiKey) },
        new() { ApplicationId = 5, CredentialTypeId = ((int)CredentialTypes.PassWord) },
        new() { ApplicationId = 5, CredentialTypeId = ((int)CredentialTypes.AsDomain) },
        new() { ApplicationId = 6, CredentialTypeId = ((int)CredentialTypes.FzDomain) },
        new() { ApplicationId = 7, CredentialTypeId = ((int)CredentialTypes.FzDomain) },
      ]);
  }
}
