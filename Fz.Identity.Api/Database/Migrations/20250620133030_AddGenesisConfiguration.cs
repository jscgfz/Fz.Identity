using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddGenesisConfiguration : Migration
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
                    { 52, 9, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", 0, null, "/", "Home" },
                    { 53, 9, "call-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamadas", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamadas", 0, null, "/call_management", "Call" },
                    { 54, 9, "reports", null, new Guid("00000000-0000-0000-0000-000000000000"), "Informes", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informes", 0, null, "/reports", "Report" },
                    { 55, 9, "campaigns", null, new Guid("00000000-0000-0000-0000-000000000000"), "Campañas", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Campañas", 0, null, "/campaigns", "Campaign" },
                    { 56, 9, "customer-id", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamada seleccionada", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamada seleccionada", 0, null, "/call_management/user_info/:customerId", "" },
                    { 57, 9, "agent-edit", null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar perfil", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar perfil", 0, null, "/agent/edit_agent/:agentId", "" },
                    { 58, 9, "agent-panel", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle panel agente", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle panel agente", 0, null, "/agent/agent_panel/:agentId", "" },
                    { 59, 9, "deatil-call-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamada seleccionada", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de llamada seleccionada", 0, null, "/call_management/detail_call_management/:customerId", "" },
                    { 60, 9, "sdfsdf", null, new Guid("00000000-0000-0000-0000-000000000000"), "asd", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "asd", 0, null, "/deatil_call_management/:agentId", "sdf" },
                    { 61, 9, "queue", null, new Guid("00000000-0000-0000-0000-000000000000"), "Colas", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Colas", 0, null, "/queue", "Queue" },
                    { 62, 9, "client-information", null, new Guid("00000000-0000-0000-0000-000000000000"), "Información del cliente", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Información del cliente", 0, null, "/call_management/client_information/:identificationNumber", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 52, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 53, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 56, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 59, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 62, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 52, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 53, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 54, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 55, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 56, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 57, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 58, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 59, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 61, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 62, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 52 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 53 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 56 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 59 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 62 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 52 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 53 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 54 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 55 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 56 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 57 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 58 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 59 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 61 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 62 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 62);
        }
    }
}
