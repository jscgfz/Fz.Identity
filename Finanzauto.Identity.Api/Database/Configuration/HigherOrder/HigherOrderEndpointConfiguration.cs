using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.HigherOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.HigherOrder;

public sealed class HigherOrderEndpointConfiguration : IEntityTypeConfiguration<HigherOrderEndpoint>
{
  public void Configure(EntityTypeBuilder<HigherOrderEndpoint> builder)
  {
    builder.ToTable("HigherOrderEndpoints", IdentitySchemas.Security);
    builder.HasIndex(row => new { row.Method, row.Route }).IsUnique();
    builder.Property(row => row.Method).HasMaxLength(8);
    builder.Property(row => row.Route).HasMaxLength(100);
    builder.Property(row => row.RequiresSecondAuthLayer).HasDefaultValue(true);
    builder.Property(row => row.RequiresThirdAuthLayer).HasDefaultValue(true);
  }
}
