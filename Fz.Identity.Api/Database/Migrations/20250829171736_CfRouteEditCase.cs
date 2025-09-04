using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class CfRouteEditCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[] { 126, 11, "PqrsManagamentDetail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar caso NO.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar caso NO.", 0, null, "/pqrs-management/edit-pqrs-detail/:pqrsId", "" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[] { new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"), 126, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"), 126 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 126);
        }
    }
}
