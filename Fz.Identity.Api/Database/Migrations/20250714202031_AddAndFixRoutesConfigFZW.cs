using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAndFixRoutesConfigFZW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "Vista de usuarios internos con cambio de estado, regristro y edición.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Path",
                value: "/carousel-images");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "Vista gestor de contenido para oficinas con cambio de estado, registro y edición.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "Vista gestor de contenido para sostenibilidad con cambio de estado, registro y edición.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Vista gestor de contenido para polizas con cambio de estado, registro y edición.", "Políticas" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[] { 82, 8, "insurancePolicies", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para pólizas de seguros con cambio de estado, registro y edición.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Pólizas de seguros", 6, 16, "/insurance-policies", "" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 82, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 82 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "Vista de usuarios internos con cambio de estado y regristro.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Path",
                value: "/carrousel-images");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "Vista gestor de contenido para oficinas con cambio de estado y registro.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "Vista gestor de contenido para sostenibilidad .");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Vista gestor de contenido para polizas.", "Polizas" });
        }
    }
}
