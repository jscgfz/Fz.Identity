using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientsPermissions3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[] { 86, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-aprove1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 86);
        }
    }
}
