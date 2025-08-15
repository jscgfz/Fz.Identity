using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAPTClientRoutesConfiguration : Migration
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
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 117, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 118, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 119, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 117,
                column: "ParentId",
                value: 34);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 118,
                column: "ParentId",
                value: 34);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 119,
                column: "ParentId",
                value: 34);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 117 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 118 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 119 });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 117,
                column: "ParentId",
                value: 98);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 118,
                column: "ParentId",
                value: 98);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 119,
                column: "ParentId",
                value: 98);
        }
    }
}
