using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authentication;

public sealed class SingleCredentialConfiguration : IEntityTypeConfiguration<SingleCredential>
{
  public void Configure(EntityTypeBuilder<SingleCredential> builder)
  {
    builder.ToTable("SingleCredentials", IdentitySchemas.Authentication);
    builder.HasKey(sc => new { sc.UserId, sc.AppId });
    builder.Property(sc => sc.UserName).IsRequired().HasMaxLength(50);
    builder.HasIndex(sc => new { sc.AppId, sc.UserName }).IsUnique();
    builder.HasOne(sc => sc.User)
           .WithMany(u => u.SingleCredentials)
           .HasForeignKey(sc => sc.UserId)
           .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(sc => sc.Application)
            .WithMany(a => a.SingleCredentials)
            .HasForeignKey(sc => sc.AppId)
            .OnDelete(DeleteBehavior.NoAction);
  }
}
