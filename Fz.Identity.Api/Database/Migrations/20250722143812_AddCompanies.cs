using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RejectionReason",
                schema: "conf",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "conf",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CompanyId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CompanyId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CompanyId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CompanyId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "CompanyId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Finanzauto" },
                    { 2, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Promotec" },
                    { 3, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Asisya" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                schema: "conf",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                schema: "conf",
                table: "Applications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Companies_CompanyId",
                schema: "conf",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CompanyId",
                schema: "conf",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "conf",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "RejectionReason",
                schema: "conf",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
