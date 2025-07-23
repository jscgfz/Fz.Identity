using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Claims;

public sealed class ClaimValueConfiguration : IEntityTypeConfiguration<ClaimValue>
{
  public void Configure(EntityTypeBuilder<ClaimValue> builder)
  {
    builder.ToTable("ClaimValues", IdentitySchemas.Security);
    builder.HasIndex(row => new { row.ClaimActionId, row.ClaimSectionId }).IsUnique();
    builder.HasOne(row => row.ClaimAction)
           .WithMany(ca => ca.Sections)
           .HasForeignKey(row => row.ClaimActionId)
           .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.ClaimSection)
            .WithMany(cs => cs.Actions)
            .HasForeignKey(row => row.ClaimSectionId)
            .OnDelete(DeleteBehavior.NoAction);
  }
}
