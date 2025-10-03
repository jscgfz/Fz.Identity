using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class RouteUniqueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Routes_ApplitionId_Name_Path",
                schema: "conf",
                table: "Routes");

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                schema: "conf",
                table: "Routes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApplitionId_Name_Path_Component",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name", "Path", "Component" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Routes_ApplitionId_Name_Path_Component",
                schema: "conf",
                table: "Routes");

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                schema: "conf",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApplitionId_Name_Path",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name", "Path" },
                unique: true);
        }
    }
}
