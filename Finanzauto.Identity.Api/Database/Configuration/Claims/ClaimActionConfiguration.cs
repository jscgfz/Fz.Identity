using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Claims;

public sealed class ClaimActionConfiguration : IEntityTypeConfiguration<ClaimAction>
{
  public void Configure(EntityTypeBuilder<ClaimAction> builder)
  {
    builder.ToTable("ClaimActions", IdentitySchemas.Security);
  }
}
