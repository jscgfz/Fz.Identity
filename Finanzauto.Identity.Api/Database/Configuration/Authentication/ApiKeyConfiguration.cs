using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authentication;

public sealed class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
  public void Configure(EntityTypeBuilder<ApiKey> builder)
  {
    builder.ToTable("ApiKeys", IdentitySchemas.Authentication);
    builder.HasIndex(row => new { row.AppId, row.Consumer }).IsUnique();
    builder.Property(row => row.Consumer).HasMaxLength(50);
    builder.HasIndex(row => row.ApiKeyHash).IsUnique();
    builder.HasOne(row => row.App)
      .WithMany(row => row.ApiKeys)
      .HasForeignKey(row => row.AppId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
