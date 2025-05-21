using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFzAppWebRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("05e9bea3-079c-4f42-bc78-72c045664ead"));

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Applications",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { 8, null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador de credenciales de usuarios de finanzauto web", null, new Guid("00000000-0000-0000-0000-000000000000"), "Finanzauto Web Admin" });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"),
                column: "ApplicationId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"),
                columns: new[] { "ApplicationId", "Name" },
                values: new object[] { 8, "Admin TI" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 14, 8, "externalUser", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista de usuarios externos con cambio de estado.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Usuario externos", 1, null, "/external-user", "" },
                    { 15, 8, "internalUser", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista de usuarios internos con cambio de estado y regristro.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Usuarios internos", 2, null, "/internal-user", "" },
                    { 16, 8, "", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestor de Contenido", 3, null, "", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 16, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 14, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 15, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 17, 8, "CarrouselImages", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para el carrousel con cambio de estado, orden, registro y detalle.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Carrusel de imagenes", 1, 16, "/carrousel-images", "" },
                    { 18, 8, "investors", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para inversionistas con cambio de estado y agregar hijos.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inversionistas", 2, 16, "/investors", "" },
                    { 19, 8, "offices", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para oficinas con cambio de estado y registro.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Oficinas", 3, 16, "/offices", "" },
                    { 20, 8, "sustainability", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para sostenibilidad .", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Sostenibilidad", 4, 16, "/sustainability", "" },
                    { 21, 8, "policies", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para polizas.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Polizas", 5, 16, "/policies", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 17, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 18, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 19, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 20, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 21, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 16 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 17 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 18 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 19 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 20 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 21 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 14 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 15 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"),
                column: "ApplicationId",
                value: 1001);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"),
                columns: new[] { "ApplicationId", "Name" },
                values: new object[] { 1001, "Admin Usuarios" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { new Guid("05e9bea3-079c-4f42-bc78-72c045664ead"), 1001, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente" });
        }
    }
}
