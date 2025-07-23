using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authorization;

public sealed class ApiKeyClaimConfiguration : IEntityTypeConfiguration<ApiKeyClaim>
{
  public void Configure(EntityTypeBuilder<ApiKeyClaim> builder)
  {
    builder.ToTable("ApiKeyClaims", IdentitySchemas.Authentication);
    builder.HasKey(akc => new { akc.ApiKeyId, akc.ClaimValueId });
    builder.HasOne(akc => akc.ApiKey)
      .WithMany(ak => ak.Claims)
      .HasForeignKey(akc => akc.ApiKeyId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(akc => akc.ClaimValue)
      .WithMany(cv => cv.ApiKeys)
      .HasForeignKey(akc => akc.ClaimValueId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
