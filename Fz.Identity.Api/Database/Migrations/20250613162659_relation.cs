using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Credentials_CredentialValue",
                schema: "auth",
                table: "Credentials");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_CredentialValue_CredentialTypeId",
                schema: "auth",
                table: "Credentials",
                columns: new[] { "CredentialValue", "CredentialTypeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Credentials_CredentialValue_CredentialTypeId",
                schema: "auth",
                table: "Credentials");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_CredentialValue",
                schema: "auth",
                table: "Credentials",
                column: "CredentialValue",
                unique: true);
        }
    }
}
