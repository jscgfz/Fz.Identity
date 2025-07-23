using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.HigherOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.HigherOrder;

public sealed class HigherOrderEndpointOriginConfiguration : IEntityTypeConfiguration<HigherOrderEndpointOrigin>
{
  public void Configure(EntityTypeBuilder<HigherOrderEndpointOrigin> builder)
  {
    builder.ToTable("HigherOrderEndpointOrigins", IdentitySchemas.Security);
    builder.HasKey(row => new { row.EndpointId, row.KeyId });
    builder.HasOne(row => row.Endpoint)
      .WithMany(endpoint => endpoint.AlloweOrigins)
      .HasForeignKey(row => row.EndpointId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.Key)
      .WithMany(row => row.AllowedEndpoints)
      .HasForeignKey(row => row.KeyId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
