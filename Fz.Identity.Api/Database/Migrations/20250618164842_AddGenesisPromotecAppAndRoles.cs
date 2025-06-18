using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddGenesisPromotecAppAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Applications",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { 9, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aplicacion atención cliente de Promotec", null, new Guid("00000000-0000-0000-0000-000000000000"), "Genesis Promotec" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"), 9, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Agente" },
                    { new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"), 9, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"));

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
