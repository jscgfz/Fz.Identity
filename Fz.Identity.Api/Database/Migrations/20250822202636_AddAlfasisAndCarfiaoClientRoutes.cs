using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAlfasisAndCarfiaoClientRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 119 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 119 });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 120, 4, "alfasis", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Alfasis", 0, 34, "", "" },
                    { 121, 11, "clients", null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", 0, null, "/clients", "https://reporteriapbx.finanzauto.com.co/carfiao.atenea.dev/icons/icon-clients-atenea-carfiao.svg" },
                    { 122, 11, "client-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de Cliente No.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de Cliente", 0, null, "/clients/client-detail/:clientId", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 120, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 120, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 121, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 122, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 123, 11, "GeneralSummary", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Información del negocio", 0, 122, "", "" },
                    { 124, 11, "Historic", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico", 0, 122, "", "" },
                    { 125, 11, "CommunicationHistory", null, new Guid("00000000-0000-0000-0000-000000000000"), "", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historial de comunicación", 0, 122, "", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 123, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 124, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 125, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 120 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 120 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 121 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 122 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 123 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 124 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"), 125 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("1f5c213e-78e3-41c6-af55-d80af0f25763"), 119, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 119, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });
        }
    }
}
