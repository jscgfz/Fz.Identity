using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAPTAndFZSAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Alias",
                value: "AteneaPT");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Alias",
                value: "Finanzaseguros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Alias",
                value: "APT");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Alias",
                value: null);
        }
    }
}
