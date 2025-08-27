using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixAuditLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payload",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "Endpoint",
                schema: "audit",
                table: "AuditLogs",
                newName: "Module");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                schema: "audit",
                table: "AuditLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "audit",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Entity",
                schema: "audit",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntityId",
                schema: "audit",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_ApplicationId",
                schema: "audit",
                table: "AuditLogs",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Applications_ApplicationId",
                schema: "audit",
                table: "AuditLogs",
                column: "ApplicationId",
                principalSchema: "conf",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Applications_ApplicationId",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.DropIndex(
                name: "IX_AuditLogs_ApplicationId",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "Entity",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "EntityId",
                schema: "audit",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "Module",
                schema: "audit",
                table: "AuditLogs",
                newName: "Endpoint");

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                schema: "audit",
                table: "AuditLogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
