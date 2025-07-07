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
    builder.HasIndex(row => new { row.ApplitionId, row.Name, row.Path }).IsUnique();
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
        new() { Id = 22, ApplitionId = 4, Name = "Inicio", Description = "Inicio", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/", ExcludeNav = true, Component = "home" },
        new() { Id = 23, ApplitionId = 4, Name = "Gestión PQRS", Description = "Gestión PQRS", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/pqrs-management", ExcludeNav = true, Component = "pqrs-management" },
        new() { Id = 24, ApplitionId = 4, Name = "Gestión llamadas", Description = "Gestión llamadas", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/call-management", ExcludeNav = true, Component = "call-management" },
        new() { Id = 25, ApplitionId = 4, Name = "Clientes", Description = "Clientes", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/clients", ExcludeNav = true, Component = "clients" },
        new() { Id = 26, ApplitionId = 4, Name = "Admin Agentes", Description = "Admin Agentes", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/agent-manager", ExcludeNav = true, Component = "agent-manager" },
        new() { Id = 27, ApplitionId = 4, Name = "WhatsApp", Description = "WhatsApp", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/whatsapp", ExcludeNav = true, Component = "whatsapp" },
        new() { Id = 28, ApplitionId = 4, Name = "Admin Comunicaciones", Description = "Admin Comunicaciones", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/communications-manager0", ExcludeNav = true, Component = "communications-manager" },
        new() { Id = 29, ApplitionId = 4, Name = "Histórico", Description = "Histórico", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/historical", ExcludeNav = true, Component = "historical" },
        new() { Id = 30, ApplitionId = 4, Name = "Informes", Description = "Informes", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/reports", ExcludeNav = true, Component = "reports" },
        new() { Id = 31, ApplitionId = 4, Name = "Resumen de caso PQRS", Description = "Resumen de caso PQRS", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/pqrs-management/pqrs-summary/:caseTypeId", ExcludeNav = true, Component = "pqrs-summary" },
        new() { Id = 32, ApplitionId = 4, Name = "Detalle de caso NO.", Description = "Detalle de caso NO.", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/pqrs-management/pqrs-detail/:pqrsId", ExcludeNav = true, Component = "pqrs-management-detail" },
        new() { Id = 33, ApplitionId = 4, Name = "Radicar PQRS", Description = "Radicar PQRS", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/pqrs-management/file-pqrs", ExcludeNav = true, Component = "file-pqrs" },
        new() { Id = 34, ApplitionId = 4, Name = "Detalle de Cliente", Description = "Detalle de Cliente", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/client/client-detail/:clientId", ExcludeNav = true, Component = "client-detail" },
        new() { Id = 40, ApplitionId = 4, Name = "Detalle Agente", Description = "Detalle Agente", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/agent-manager/agent-detail/:agentName", ExcludeNav = true, Component = "agent-detail" },
        new() { Id = 41, ApplitionId = 4, Name = "Calendario", Description = "Calendario", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/calendar", ExcludeNav = true, Component = "calendar" },
        new() { Id = 45, ApplitionId = 4, Name = "Correos", Description = "Correos", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/email", ExcludeNav = true, Component = "email" },
        new() { Id = 46, ApplitionId = 4, Name = "Gestión de usuarios", Description = "Gestión de usuarios", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/user-management", ExcludeNav = true, Component = "user-management" },
        new() { Id = 47, ApplitionId = 4, Name = "Gestión de roles", Description = "Gestión de roles", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/role-management", ExcludeNav = true, Component = "role-management" },
        new() { Id = 48, ApplitionId = 4, Name = "Histórico de gestiones", Description = "Histórico de gestiones", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/history-management", ExcludeNav = true, Component = "history-management" },
        new() { Id = 49, ApplitionId = 4, Name = "Gestión de usuarios", Description = "Gestión de usuarios", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/user-management/create-user", ExcludeNav = true, Component = "actions-user" },
        new() { Id = 50, ApplitionId = 4, Name = "Gestión de usuarios", Description = "Gestión de usuarios", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/user-management/edit-user/:id", ExcludeNav = true, Component = "actions-user" },
        new() { Id = 51, ApplitionId = 4, Name = "Gestión de usuarios", Description = "Gestión de usuarios", UrlImg = "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif", Path = "/user-management/view-user/:id", ExcludeNav = true, Component = "actions-user" },
        new() { Id = 52, ApplitionId = 9, Name = "Inicio", Description = "Inicio", UrlImg = "Home", Path = "/", ExcludeNav = false, Component = "home" },
        new() { Id = 53, ApplitionId = 9, Name = "Gestión de llamadas", Description = "Gestión de llamadas", UrlImg = "Call", Path = "/call_management", ExcludeNav = false, Component = "call-management" },
        new() { Id = 54, ApplitionId = 9, Name = "Informes", Description = "Informes", UrlImg = "Report", Path = "/reports", ExcludeNav = false, Component = "reports" },
        new() { Id = 55, ApplitionId = 9, Name = "Campañas", Description = "Campañas", UrlImg = "Campaign", Path = "/campaigns", ExcludeNav = false, Component = "campaigns" },
        new() { Id = 56, ApplitionId = 9, Name = "Gestión de llamada seleccionada", Description = "Gestión de llamada seleccionada", UrlImg = string.Empty, Path = "/call_management/user_info/:customerId", ExcludeNav = true, Component = "customer-id" },
        new() { Id = 57, ApplitionId = 9, Name = "Editar perfil", Description = "Editar perfil", UrlImg = string.Empty, Path = "/agent/edit_agent/:agentId", ExcludeNav = true, Component = "agent-edit" },
        new() { Id = 58, ApplitionId = 9, Name = "Detalle panel agente", Description = "Detalle panel agente", UrlImg = string.Empty, Path = "/agent/agent_panel/:agentId", ExcludeNav = true, Component = "agent-panel" },
        new() { Id = 59, ApplitionId = 9, Name = "Gestión de llamada seleccionada", Description = "Gestión de llamada seleccionada", UrlImg = string.Empty, Path = "/call_management/detail_call_management/:customerId", ExcludeNav = true, Component = "deatil-call-management" },
        new() { Id = 60, ApplitionId = 9, Name = "asd", Description = "asd", UrlImg = "sdf", Path = "/deatil_call_management/:agentId", ExcludeNav = false, Component = "sdfsdf" },
        new() { Id = 61, ApplitionId = 9, Name = "Colas", Description = "Colas", UrlImg = "Queue", Path = "/queue", ExcludeNav = false, Component = "queue" },
        new() { Id = 62, ApplitionId = 9, Name = "Información del cliente", Description = "Información del cliente", UrlImg = string.Empty, Path = "/call_management/client_information/:identificationNumber", ExcludeNav = true, Component = "client-information" },
        new() { Id = 63, ApplitionId = 3, Name = "Inicio", Description = string.Empty, UrlImg = string.Empty, Path = "/", ExcludeNav = false, Component = "home" },
        new() { Id = 64, ApplitionId = 3, Name = "Indicadores", Description = string.Empty, UrlImg = string.Empty, Path = "/indicators", ExcludeNav = false, Component = "indicators" },
        new() { Id = 65, ApplitionId = 3, Name = "Proveedores", Description = string.Empty, UrlImg = string.Empty, Path = "/providers", ExcludeNav = false, Component = "providers" },
        new() { Id = 66, ApplitionId = 3, Name = "Registro proveedor", Description = string.Empty, UrlImg = string.Empty, Path = "/providers/create-provider", ExcludeNav = true, Component = "create-provider" },
        new() { Id = 67, ApplitionId = 3, Name = "Detalle proveedor", Description = string.Empty, UrlImg = string.Empty, Path = "/providers/:providerId", ExcludeNav = true, Component = "detail-provider" },
        new() { Id = 68, ApplitionId = 3, Name = "Aseguradoras", Description = string.Empty, UrlImg = string.Empty, Path = "/insurers", ExcludeNav = false, Component = "insurers" },
        new() { Id = 69, ApplitionId = 3, Name = "Registro aseguradora", Description = string.Empty, UrlImg = string.Empty, Path = "/insurers/create-insurer", ExcludeNav = true, Component = "create-insurer" },
        new() { Id = 70, ApplitionId = 3, Name = "Aseguradoras", Description = string.Empty, UrlImg = string.Empty, Path = "/insurers/:insurerId", ExcludeNav = true, Component = "detail-insurer" },
        new() { Id = 71, ApplitionId = 3, Name = "Gestiones", Description = string.Empty, UrlImg = string.Empty, Path = "/", ExcludeNav = false, Component = "home" },
      ]);
  }
}
