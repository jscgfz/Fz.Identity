using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarfiaoAndPTRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Nuevo usuario");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Editar usuario");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Detalle usuario");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 93,
                column: "Component",
                value: "user-management");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 94,
                column: "Component",
                value: "role-management");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 95,
                column: "Component",
                value: "management-history");

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 98, 4, "pqrs-management-edit", null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar detalle de caso NO.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar detalle de caso NO.", 2, null, "/pqrs-management/edit-pqrs-detail/:pqrsId", "" },
                    { 99, 11, "file-pqrs", null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", 0, null, "/pqrs-management/file-pqrs", "" },
                    { 100, 9, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo usuario", 0, null, "/user-management/create-user", "" },
                    { 101, 9, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar usuario", 0, null, "/user-management/edit-user/:id", "" },
                    { 102, 9, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle usuario", 0, null, "/user-management/view-user/:id", "" },
                    { 103, 9, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle rol", 0, null, "/role-management/view-rol/:id", "" },
                    { 104, 9, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Editar rol", 0, null, "/role-management/edit-rol/:id", "" },
                    { 105, 9, "rol-actions", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear rol", 0, null, "/role-management/create-rol", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 98, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 100, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 101, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 102, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 103, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 104, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 105, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 99, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 98 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 100 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 101 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 102 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 103 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 104 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"), 105 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 99 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Gestión de usuarios");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Gestión de usuarios");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Gestión de usuarios");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 93,
                column: "Component",
                value: "user_management");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 94,
                column: "Component",
                value: "role_management");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 95,
                column: "Component",
                value: "management_history");
        }
    }
}
