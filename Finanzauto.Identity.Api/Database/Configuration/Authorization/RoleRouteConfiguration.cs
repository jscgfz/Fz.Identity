using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authorization;

public sealed class RoleRouteConfiguration : IEntityTypeConfiguration<RoleRoute>
{
  public void Configure(EntityTypeBuilder<RoleRoute> builder)
  {
    builder.ToTable("RoleRoute", IdentitySchemas.Authentication);
    builder.HasKey(rr => new { rr.RoleId, rr.RouteId });
    builder.HasOne(rr => rr.Role)
      .WithMany(r => r.Routes)
      .HasForeignKey(rr => rr.RoleId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(rr => rr.Route)
      .WithMany(r => r.Roles)
      .HasForeignKey(rr => rr.RouteId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
