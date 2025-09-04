using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientsPermissions2 : Migration
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
                    { 62, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-aprove1" },
                    //{ 63, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-aprove1" },
                    { 64, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-aprove1" },
                    { 65, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-aprove1" },
                    { 66, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-aprove1" },
                    { 67, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-aprove1" },
                    //{ 68, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.main" },
                    { 69, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.create" },
                    { 70, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.update" },
                    { 71, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.delete" },
                    { 72, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.download" },
                    { 73, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null, new Guid("00000000-0000-0000-0000-000000000000"), 5, 7, null, "home.aprove" },
                    //{ 74, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.main" },
                    { 75, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.create" },
                    { 76, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.update" },
                    { 77, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.delete" },
                    { 78, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.download" },
                    { 79, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null, new Guid("00000000-0000-0000-0000-000000000000"), 6, 1, null, "pqrs.aprove" },
                    //{ 80, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.main" },
                    { 81, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.create" },
                    { 82, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.update" },
                    { 83, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.delete" },
                    { 84, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.download" },
                    { 85, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión Clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), 7, 1, null, "clents.aprove" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 62);

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Claims",
            //    keyColumn: "Id",
            //    keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 67);

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Claims",
            //    keyColumn: "Id",
            //    keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 73);

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Claims",
            //    keyColumn: "Id",
            //    keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 79);

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Claims",
            //    keyColumn: "Id",
            //    keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 85);
        }
    }
}
