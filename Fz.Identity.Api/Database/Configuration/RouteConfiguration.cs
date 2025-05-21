using Fz.Identity.Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route = Fz.Identity.Api.Database.Entities.Route;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RouteConfiguration : IEntityTypeConfiguration<Route>
{
  public void Configure(EntityTypeBuilder<Route> builder)
  {

    builder.ToTable("Routes", IdentityContextSchemas.Configuration);
    builder.HasIndex(row => new { row.ApplitionId, row.Name }).IsUnique();
    builder.HasOne(row => row.Application)
      .WithMany(row => row.Routes)
      .HasForeignKey(row => row.ApplitionId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.Parent)
      .WithMany(row => row.Children)
      .HasForeignKey(row => row.ParentId)
      .OnDelete(DeleteBehavior.NoAction);

    builder
      .HasData([
        new() { Id = 1, ApplitionId = 7, Name = "Tus Solicitudes", Description = "Toda la información sobre el progreso y cualquier actualización relevante de los trámites.", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/your-requests", ExcludeNav = true, Component = "your-requests" },
        new() { Id = 2, ApplitionId = 7, Name = "Inicio", Description = "Inicio", UrlImg = string.Empty, Path = "/", ExcludeNav = true, Component = "home" },
        new() { Id = 3, ApplitionId = 7, Name = "Detalle del cliente", Description = "Detalle e información del cliente.", UrlImg = string.Empty, Path = "/your-requests/request-client-detail/:requestId", ExcludeNav = true, Component = "request-client-detail" },
        new() { Id = 4, ApplitionId = 7, Name = "Radicación de crédito", Description = "Aquí podrás radicar solicitudes y seguir sus avance paso a paso.", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/76c401b9fc50c1d94bd6dbf81b85f679.jfif", Path = "/credit-filing", ExcludeNav = true, Component = "credit-filing" },
        new() { Id = 14, ApplitionId = 8, Name = "Usuario externos", Description = "Vista de usuarios externos con cambio de estado.", UrlImg = string.Empty, Path = "/external-user", ExcludeNav = false, Component = "externalUser", Order = 1 },
        new() { Id = 15, ApplitionId = 8, Name = "Usuarios internos", Description = "Vista de usuarios internos con cambio de estado y regristro.", UrlImg = string.Empty, Path = "/internal-user", ExcludeNav = false, Component = "internalUser", Order = 2 },
        new() { Id = 16, ApplitionId = 8, Name = "Gestor de Contenido", Description = string.Empty, UrlImg = string.Empty, Path = string.Empty, ExcludeNav = false, Component = string.Empty, Order = 3 },
        new() { Id = 17, ApplitionId = 8, Name = "Carrusel de imagenes", Description = "Vista gestor de contenido para el carrousel con cambio de estado, orden, registro y detalle.", UrlImg = string.Empty, Path = "/carrousel-images", ExcludeNav = false, Component = "CarrouselImages", Order =1, ParentId = 16 },
        new() { Id = 18, ApplitionId = 8, Name = "Inversionistas", Description = "Vista gestor de contenido para inversionistas con cambio de estado y agregar hijos.", UrlImg = string.Empty, Path = "/investors", ExcludeNav = false, Component = "investors", Order =2, ParentId = 16 },
        new() { Id = 19, ApplitionId = 8, Name = "Oficinas", Description = "Vista gestor de contenido para oficinas con cambio de estado y registro.", UrlImg = string.Empty, Path = "/offices", ExcludeNav = false, Component = "offices", Order =3, ParentId = 16 },
        new() { Id = 20, ApplitionId = 8, Name = "Sostenibilidad", Description = "Vista gestor de contenido para sostenibilidad .", UrlImg = string.Empty, Path = "/sustainability", ExcludeNav = false, Component = "sustainability", Order = 4, ParentId = 16 },
        new() { Id = 21, ApplitionId = 8, Name = "Polizas", Description = "Vista gestor de contenido para polizas.", UrlImg = string.Empty, Path = "/policies", ExcludeNav = false, Component = "policies", Order = 5, ParentId = 16 },
      ]);
  }
}
