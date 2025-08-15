using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFzsRoutesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 2, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 2, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 2, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExcludeNav",
                value: false);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExcludeNav",
                value: false);

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 6, 7, "admin-panel", null, new Guid("00000000-0000-0000-0000-000000000000"), "Accede a las herramientas y configuraciones esenciales para gestionar usuarios.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Panel Administrativo", 0, null, "/admin-panel", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.webp" },
                    { 9, 7, "admin-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Crea nuevos usuarios en el sistema", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear nuevo usuario", 0, null, "/admin-panel/create-user", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.webp" },
                    { 11, 7, "admin-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Edita los usuarios del sistema", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de usuario", 0, null, "/admin-panel/user/:userId", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.webp" },
                    { 13, 7, "reports", null, new Guid("00000000-0000-0000-0000-000000000000"), "Consulta y descarga tus informes de manera rápida y sencilla.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Tus informes", 0, null, "/reports", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.webp" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 6, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 9, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 11, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 13, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 13, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 6 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 9 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 11 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 13 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 13 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExcludeNav",
                value: true);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExcludeNav",
                value: true);
        }
    }
}
