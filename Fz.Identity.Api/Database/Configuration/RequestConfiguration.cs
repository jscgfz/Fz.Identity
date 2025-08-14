using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
  public void Configure(EntityTypeBuilder<Request> builder)
  {
    builder.ToTable("Requests", IdentityContextSchemas.Configuration);

    builder
      .HasOne(row => row.Role)
      .WithMany(row => row.Requests)
      .HasForeignKey(row => row.RoleId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
