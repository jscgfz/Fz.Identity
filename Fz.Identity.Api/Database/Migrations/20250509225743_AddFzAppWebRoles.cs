using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFzAppWebRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("05e9bea3-079c-4f42-bc78-72c045664ead"), 1001, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Cliente" },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 1001, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Contenido" },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 1001, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Usuarios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("05e9bea3-079c-4f42-bc78-72c045664ead"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"));
        }
    }
}
