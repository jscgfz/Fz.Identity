using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTIRoleRoutesCarfiao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ActiveDirectoryRoleId", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), null, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "T.I" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 128, 11, "user-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 1, null, "/home", "" },
                    { 129, 11, "role-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", 2, null, "/role-management", "" },
                    { 130, 11, "history-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", 3, null, "/history-management", "" },
                    { 131, 11, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo usuario", 0, null, "/user-management/create-user", "" },
                    { 132, 11, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar usuario", 0, null, "/user-management/edit-user/:id", "" },
                    { 133, 11, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle usuario", 0, null, "/user-management/view-user/:id", "" },
                    { 134, 11, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle rol", 0, null, "/role-management/view-rol/:id", "" },
                    { 135, 11, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar rol", 0, null, "/role-management/edit-rol/:id", "" },
                    { 136, 11, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear rol", 0, null, "/role-management/create-rol", "" },
                    { 137, 11, "detail-request-editing", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle solicitud edición", 0, null, "/detail-request-editing/:id", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 128, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 129, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 130, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 131, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 132, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 133, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 134, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 135, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 136, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 137, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 128 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 129 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 130 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 131 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 132 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 133 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 134 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 135 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 136 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"), 137 });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a"));

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 137);
        }
    }
}
