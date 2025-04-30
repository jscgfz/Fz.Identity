using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class routesImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "conf",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "conf",
                table: "AllowedCredentials",
                columns: new[] { "ApplicationId", "CredentialTypeId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 2, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 5, 5 }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "UrlImg" },
                values: new object[] { "Toda la información sobre el progreso y cualquier actualización relevante de los trámites.", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Inicio");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Detalle e información del cliente.");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "UrlImg" },
                values: new object[] { "Aquí podrás radicar solicitudes y seguir sus avance paso a paso.", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/76c401b9fc50c1d94bd6dbf81b85f679.jfif" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Users",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "IdentificationNumber", "ModifiedAtUtc", "ModifiedBy", "Name", "PrincipalEmail", "PrincipalEmailConfirmed", "PrincipalPhoneNumber", "PrincipalPhoneNumberConfirmed", "Surname", "Username" },
                values: new object[,]
                {
                    { new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000006", null, new Guid("00000000-0000-0000-0000-000000000000"), "Astrid", "astrid.meneses@asisya.com", false, "1000000006", false, "Meneses", "astrid.meneses" },
                    { new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000003", null, new Guid("00000000-0000-0000-0000-000000000000"), "Laura", "laura.rueda@asisya.com", false, "1000000003", false, "Rueda", "laura.rueda" },
                    { new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000007", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jose Willy Duvan", "jose.carrillo@asisya.com.co", false, "1000000007", false, "Carrillo Carrillo", "jose.carrillo" },
                    { new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000000", null, new Guid("00000000-0000-0000-0000-000000000000"), "Julieth", "julieth.quinones@asisya.com", false, "1000000000", false, "Quiñiones", "julieth.quinones" },
                    { new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000001", null, new Guid("00000000-0000-0000-0000-000000000000"), "Paula", "paula.moreno@asisya.com", false, "1000000001", false, "Moreno", "paula.moreno" },
                    { new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000004", null, new Guid("00000000-0000-0000-0000-000000000000"), "Arlein", "arlein.pomar@asisya.com", false, "1000000004", false, "Pomar", "arlein.pomar" },
                    { new Guid("f015f137-5352-48e9-8120-609639131906"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000005", null, new Guid("00000000-0000-0000-0000-000000000000"), "Nicolas", "nicolas.rico@asisya.com", false, "1000000005", false, "Rico", "nicolas.rico" },
                    { new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000002", null, new Guid("00000000-0000-0000-0000-000000000000"), "Oscar", "oscar.vinasco@asisya.com", false, "1000000002", false, "Vinasco", "oscar.vinasco" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Credentials",
                columns: new[] { "Id", "CredentialEndUtc", "CredentialTypeId", "CredentialValue", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "UserId" },
                values: new object[,]
                {
                    { 13, null, 5, "{\"Username\":\"jose.carrillo\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7") },
                    { 14, null, 5, "{\"Username\":\"nicolas.rico\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f015f137-5352-48e9-8120-609639131906") },
                    { 15, null, 5, "{\"Username\":\"astrid.meneses\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40") },
                    { 16, null, 5, "{\"Username\":\"arlein.pomar\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace") },
                    { 17, null, 5, "{\"Username\":\"julieth.quinones\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3") },
                    { 18, null, 5, "{\"Username\":\"laura.rueda\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d") },
                    { 19, null, 5, "{\"Username\":\"paula.moreno\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220") },
                    { 20, null, 5, "{\"Username\":\"oscar.vinasco\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802") }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "UserApplications",
                columns: new[] { "ApplicationId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { 3, new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("f015f137-5352-48e9-8120-609639131906"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "AllowedCredentials",
                keyColumns: new[] { "ApplicationId", "CredentialTypeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("f015f137-5352-48e9-8120-609639131906") });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "UserApplications",
                keyColumns: new[] { "ApplicationId", "UserId" },
                keyValues: new object[] { 3, new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802") });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f015f137-5352-48e9-8120-609639131906"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"));

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "conf",
                table: "Routes");

            migrationBuilder.InsertData(
                schema: "conf",
                table: "AllowedCredentials",
                columns: new[] { "ApplicationId", "CredentialTypeId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImg",
                value: "");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImg",
                value: "");
        }
    }
}
