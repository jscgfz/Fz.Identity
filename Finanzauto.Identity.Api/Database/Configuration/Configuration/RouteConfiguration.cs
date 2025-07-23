using Finanzauto.Identity.Api.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Configuration;

public sealed class RouteConfiguration : IEntityTypeConfiguration<Domain.Entities.Configuration.Route>
{
  public void Configure(EntityTypeBuilder<Domain.Entities.Configuration.Route> builder)
  {
    builder.ToTable("Routes", IdentitySchemas.Configuration);
    builder.HasIndex(row => new { row.Name, row.Path, row.Component })
      .IsUnique();
  }
}
