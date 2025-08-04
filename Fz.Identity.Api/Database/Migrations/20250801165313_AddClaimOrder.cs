using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "auth",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 13,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 14,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 15,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 16,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 17,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 18,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 19,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 20,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 21,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 22,
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 23,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 24,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 25,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 26,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 27,
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 28,
                column: "Order",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "auth",
                table: "Claims");
        }
    }
}
