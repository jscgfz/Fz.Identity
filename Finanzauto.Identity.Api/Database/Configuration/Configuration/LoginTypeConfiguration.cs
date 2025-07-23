using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Domain.Enums.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class LoginTypeConfiguration : IEntityTypeConfiguration<LoginType>
{
  public void Configure(EntityTypeBuilder<LoginType> builder)
  {
    builder.ToTable("LoginTypes", IdentitySchemas.Security);
    builder.Property(row => row.DomainName).HasMaxLength(50);
  }
}
