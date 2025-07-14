using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveDirectoryNameRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveDirectoryName",
                schema: "auth",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22526b31-4f44-4775-b5b4-6b07005dda60"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2513a3ec-519a-437c-9f47-d3ed69b5cd06"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89789f4a-570d-451d-b99b-69127421f1fe"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d525cf87-3c00-48dc-992d-284d2a12772f"),
                column: "ActiveDirectoryName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDirectoryName",
                schema: "auth",
                table: "Roles");
        }
    }
}
