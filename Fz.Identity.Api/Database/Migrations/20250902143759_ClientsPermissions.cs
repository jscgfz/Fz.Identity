using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class ClientsPermissions : Migration
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
                    { 8, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", 6 },
                    { 9, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle Cliente", 7 },
                    { 10, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Información Negocio", 7 },
                    { 11, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico actualización de datos", 7 },
                    { 12, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico alfasis", 7 },
                    { 13, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Información de casos", 7 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[,]
                {
                    { 32, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-vew" },
                    { 33, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-create" },
                    { 34, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-delete" },
                    { 35, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-download" },
                    { 36, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 8, 1, null, "pqrs.create-aprove" },
                    { 37, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-vew" },
                    { 38, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-create" },
                    { 39, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-delete" },
                    { 40, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-download" },
                    { 41, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle cliente - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 9, 1, null, "client.detail-aprove" },
                    { 42, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-vew" },
                    { 43, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-create" },
                    { 44, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-delete" },
                    { 45, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-download" },
                    { 46, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información negocio - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 10, 1, null, "client.bi-aprove" },
                    { 47, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-vew" },
                    { 48, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-create" },
                    { 49, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-delete" },
                    { 50, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-download" },
                    { 51, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico actualización de datos - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 11, 1, null, "client.duh-aprove" },
                    { 52, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-vew" },
                    { 53, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-create" },
                    { 54, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-delete" },
                    { 55, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-download" },
                    { 56, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - Histórico alfasis - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 12, 1, null, "client.ah-aprove" },
                    { 57, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-vew" },
                    { 58, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-create" },
                    { 59, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-delete" },
                    { 60, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - descargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-download" },
                    { 61, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente - información de casos - aprovar", null, new Guid("00000000-0000-0000-0000-000000000000"), 13, 1, null, "client.ci-aprove" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
