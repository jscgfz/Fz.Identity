using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAFZApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Applications",
                columns: new[] { "Id", "Alias", "CompanyId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { 12, null, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea para Finanzauto", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Finanzauto" });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 138,
                column: "Order",
                value: 4);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ActiveDirectoryRoleId", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { new Guid("3d57d4de-0231-4d89-9ddc-c31761cc2765"), null, 12, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Asesor" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[] { 139, 12, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", 0, null, "/home", "" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[] { new Guid("3d57d4de-0231-4d89-9ddc-c31761cc2765"), 139, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("3d57d4de-0231-4d89-9ddc-c31761cc2765"), 139 });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3d57d4de-0231-4d89-9ddc-c31761cc2765"));

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 138,
                column: "Order",
                value: 0);
        }
    }
}
