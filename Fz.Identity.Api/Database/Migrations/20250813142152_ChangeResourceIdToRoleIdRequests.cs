using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeResourceIdToRoleIdRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceId",
                schema: "conf",
                table: "Requests",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RoleId",
                schema: "conf",
                table: "Requests",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Roles_RoleId",
                schema: "conf",
                table: "Requests",
                column: "RoleId",
                principalSchema: "auth",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Roles_RoleId",
                schema: "conf",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RoleId",
                schema: "conf",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "conf",
                table: "Requests",
                newName: "ResourceId");
        }
    }
}
