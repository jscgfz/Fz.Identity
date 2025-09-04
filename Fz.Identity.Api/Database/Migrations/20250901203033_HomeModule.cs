using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class HomeModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 5, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null },
                    { 6, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null },
                    { 7, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", null }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[] { 29, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.main" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
