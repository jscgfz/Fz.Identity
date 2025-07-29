using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                schema: "auth",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "conf",
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
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Areas",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Comercial" },
                    { 2, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Operaciones" },
                    { 3, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Conciliaciones" },
                    { 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Indemnizaciones" },
                    { 5, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Cartera" }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f7b3712-0829-4a4b-a3c5-f38f35e37ca8"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c5a2e53-4182-4743-a36d-cf116ad3b49e"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f015f137-5352-48e9-8120-609639131906"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"),
                column: "AreaId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"),
                column: "AreaId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AreaId",
                schema: "auth",
                table: "Users",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Areas_AreaId",
                schema: "auth",
                table: "Users",
                column: "AreaId",
                principalSchema: "conf",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Areas_AreaId",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "conf");

            migrationBuilder.DropIndex(
                name: "IX_Users_AreaId",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AreaId",
                schema: "auth",
                table: "Users");
        }
    }
}
