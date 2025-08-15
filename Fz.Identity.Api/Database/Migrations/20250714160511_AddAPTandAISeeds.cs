using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAPTandAISeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 72, 4, "TemplateManagement", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de plantillas", 1, 28, "/template-management", "" },
                    { 73, 4, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle rol", 0, null, "/role-management/view-rol/:id", "" },
                    { 74, 4, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar rol", 0, null, "/role-management/edit-rol/:id ", "" },
                    { 75, 4, "horol-actionsme", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear rol", 0, null, "/role-management/create-rol", "" },
                    { 76, 2, "my-calendar", null, new Guid("00000000-0000-0000-0000-000000000000"), "Mi calendario.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Mi calendario", 0, null, "/my-calendar", "" },
                    { 77, 2, "detail-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión detallada", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión detallada", 1, null, "/detail-management", "" },
                    { 78, 2, "validate-customer-info", null, new Guid("00000000-0000-0000-0000-000000000000"), "Validar los datos del cliente", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Validar de datos", 2, null, "/validate-customer-info", "" },
                    { 79, 2, "thirdparty-request", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestionar las solicitudes de terceros", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitud de terceros", 3, null, "/thirdparty-request", "" },
                    { 80, 2, "role-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrar los roles del sistema", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", 4, null, "/role-management", "" },
                    { 81, 2, "change-history", null, new Guid("00000000-0000-0000-0000-000000000000"), "Visualizar los cambios realizados en el sistema", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historial de cambios", 5, null, "/change-history", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    //{ new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 72, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    //{ new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 73, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    //{ new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 74, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    //{ new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 75, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 76, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 77, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 78, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 79, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 80, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 81, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 76, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 77, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 78, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 79, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 80, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 81, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 72 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 73 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 74 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("2514961b-2fb5-4494-95b9-64787b3a5ca7"), 75 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 76 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 77 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 78 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 79 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 80 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"), 81 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 76 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 77 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 78 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 79 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 80 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"), 81 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 81);
        }
    }
}
