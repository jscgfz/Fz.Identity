using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Claims;

public sealed class ClaimSectionConfiguration : IEntityTypeConfiguration<ClaimSection>
{
  public void Configure(EntityTypeBuilder<ClaimSection> builder)
  {
    builder.ToTable("ClaimSections", IdentitySchemas.Security);
  }
}
