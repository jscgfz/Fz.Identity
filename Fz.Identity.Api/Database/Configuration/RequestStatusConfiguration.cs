using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
{
  public void Configure(EntityTypeBuilder<RequestStatus> builder)
  {
    builder.ToTable("RequestStatuses", IdentityContextSchemas.Configuration);
    builder.Property(row => row.Name)
      .HasField("_name");
    builder.Ignore(row => row.Type);
    builder.HasData([
      new RequestStatus { Id = 1, Type = RequestStatuses.Approved, Description = "Solicitud aprobada, puede hacerse la edición" },
      new RequestStatus { Id = 2, Type = RequestStatuses.Pending, Description = "Solicitud pendiente por gestión" },
      new RequestStatus { Id = 3, Type = RequestStatuses.Rejected, Description = "Solicitud rechazada, no puede hacerse la edición" },
      new RequestStatus { Id = 4, Type = RequestStatuses.Expired, Description = "Solicitud vencida, no se atendió dentro de los tiempos" },
      ]);
  }
}
