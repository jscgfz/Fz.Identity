using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRouteAndRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"),
                column: "Name",
                value: "Administrador");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"),
                column: "Name",
                value: "Agente");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ActiveDirectoryRoleId", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("1d2a7c69-3d10-4047-a927-0292389c00a7"), null, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Area" },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), null, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "SI" },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), null, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "TI" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 106, 3, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edición", 0, null, "/", "https://reporteriapbx.finanzauto.com.co/asisya.atenea.dev/icons/edit-requests.svg" },
                    { 107, 3, "request-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle solicitud", 0, null, "/edit-requests/:requestId", "" },
                    { 108, 3, "user-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 0, null, "/user-management", "https://reporteriapbx.finanzauto.com.co/asisya.atenea.dev/icons/user-management.svg" },
                    { 109, 3, "create-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo usuario", 0, null, "/user-managment/create-user", "" },
                    { 110, 3, "detail-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle del usuario", 0, null, "/user-managment/detail-user/:userId", "" },
                    { 111, 3, "edit-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar usuario", 0, null, "/user-managment/edit-user/:userId", "" },
                    { 112, 3, "role-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", 0, null, "/role-management", "https://reporteriapbx.finanzauto.com.co/asisya.atenea.dev/icons/role-management.svg" },
                    { 113, 3, "role-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de rol", 0, null, "/role-management/role-detail/:roleId", "" },
                    { 114, 3, "edit-role", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar rol", 0, null, "/role-management/edit-role/:roleId", "" },
                    { 115, 3, "history-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", 0, null, "/history-management", "https://reporteriapbx.finanzauto.com.co/asisya.atenea.dev/icons/history-management.svg" },
                    { 116, 3, "management-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle solicitud", 0, null, "/history-management/:managementId", "" },
                    { 117, 4, "GeneralSummary", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Información del negocio", 0, 98, "", "" },
                    { 118, 4, "Historic", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico", 0, 98, "", "" },
                    { 119, 4, "CommunicationHistory", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historial de comunicación", 0, 98, "", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 106, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 107, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 110, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 112, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 113, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 115, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 117, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 118, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 119, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 106, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 107, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 108, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 109, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 110, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 111, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 112, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 113, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 114, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 115, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 116, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 106 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 107 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 110 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 112 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 113 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 115 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 117 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 118 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 119 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 106 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 107 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 108 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 109 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 110 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 111 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 112 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 113 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 114 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 115 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"), 116 });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1d2a7c69-3d10-4047-a927-0292389c00a7"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8b2d7cde-fac7-4c8f-9cc5-d3053568b300"));

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"),
                column: "Name",
                value: "Coordinador");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"),
                column: "Name",
                value: "Asesor");
        }
    }
}
