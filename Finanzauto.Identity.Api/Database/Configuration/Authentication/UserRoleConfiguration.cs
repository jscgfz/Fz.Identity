using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Authentication;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
  public void Configure(EntityTypeBuilder<UserRole> builder)
  {
    builder.ToTable("UserRoles", IdentitySchemas.Security);
    builder.HasKey(ur => new { ur.UserId, ur.RoleId });
    builder.HasOne(row => row.User)
           .WithMany(u => u.AsignedRoles)
           .HasForeignKey(ur => ur.UserId)
           .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(ur => ur.Role)
            .WithMany(r => r.AsignedUsers)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
  }
}
