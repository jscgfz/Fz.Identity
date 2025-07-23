using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authentication;

public sealed class DomainCredentialConfiguration : IEntityTypeConfiguration<DomainCredential>
{
  public void Configure(EntityTypeBuilder<DomainCredential> builder)
  {
    builder.ToTable("DomainCredentials", IdentitySchemas.Authentication);
    builder.Property(row => row.LoginConfirmed).HasDefaultValue(false);
    builder.HasIndex(row => new { row.UserName, row.LoginTypeId }).IsUnique();
    builder.HasOne(row => row.User).WithMany(u => u.Credentials).HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.LoginType).WithMany(u => u.Credentials).HasForeignKey(ur => ur.LoginTypeId).OnDelete(DeleteBehavior.NoAction);
  }
}
