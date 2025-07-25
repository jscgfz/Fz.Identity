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
    builder.HasData([
      new RequestStatus { Id = (int)RequestStatuses.Approved, Name = "Aprobado", Description = "Solicitud aprobada, puede hacerse la edición" },
      new RequestStatus { Id = (int)RequestStatuses.Pending,  Name = "Pendiente", Description = "Solicitud pendiente por gestión" },
      new RequestStatus { Id = (int)RequestStatuses.Rejected, Name = "Rechazado", Description = "Solicitud rechazada, no puede hacerse la edición" },
      new RequestStatus { Id = (int)RequestStatuses.Expired,  Name = "Vencido", Description = "Solicitud vencida, no se atendió dentro de los tiempos" },
      ]);
  }
}
