using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.HigherOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.HigherOrder;

public sealed class HigherOrderKeyConfiguration : IEntityTypeConfiguration<HigherOrderKey>
{
  public void Configure(EntityTypeBuilder<HigherOrderKey> builder)
  {
    builder.ToTable("HigherOrderOrigins", IdentitySchemas.Security);
  }
}
