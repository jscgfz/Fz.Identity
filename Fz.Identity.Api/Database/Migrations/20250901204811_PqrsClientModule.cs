using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class PqrsClientModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[,]
                {
                    { 30, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.main" },
                    { 31, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.main" }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Solicitudes de edición");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Soliciitudes de edición");
        }
    }
}
