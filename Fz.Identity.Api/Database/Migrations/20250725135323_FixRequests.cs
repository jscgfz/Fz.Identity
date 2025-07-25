using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequiresConfirmation",
                schema: "conf",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aprobado");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pendiente");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rechazado");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Vencido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiresConfirmation",
                schema: "conf",
                table: "Requests");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Approved");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pending");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rejected");

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Expired");
        }
    }
}
