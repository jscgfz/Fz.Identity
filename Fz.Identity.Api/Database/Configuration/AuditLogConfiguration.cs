using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
  public void Configure(EntityTypeBuilder<AuditLog> builder)
  {
    builder.ToTable("AuditLogs", IdentityContextSchemas.Audit);
  }
}
