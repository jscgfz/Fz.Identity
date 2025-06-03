using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class OptionalUserprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_IdentificationNumber",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PrincipalPhoneNumber",
                schema: "auth",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalPhoneNumber",
                schema: "auth",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                schema: "auth",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "C",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "C");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentificationNumber",
                schema: "auth",
                table: "Users",
                column: "IdentificationNumber",
                unique: true,
                filter: "[IdentificationNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrincipalPhoneNumber",
                schema: "auth",
                table: "Users",
                column: "PrincipalPhoneNumber",
                unique: true,
                filter: "[PrincipalPhoneNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_IdentificationNumber",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PrincipalPhoneNumber",
                schema: "auth",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PrincipalPhoneNumber",
                schema: "auth",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                schema: "auth",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "C",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "C");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentificationNumber",
                schema: "auth",
                table: "Users",
                column: "IdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrincipalPhoneNumber",
                schema: "auth",
                table: "Users",
                column: "PrincipalPhoneNumber",
                unique: true);
        }
    }
}
