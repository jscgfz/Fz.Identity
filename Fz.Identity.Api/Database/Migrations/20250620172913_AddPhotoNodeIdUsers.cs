using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoNodeIdUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoNodeId",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f7b3712-0829-4a4b-a3c5-f38f35e37ca8"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c5a2e53-4182-4743-a36d-cf116ad3b49e"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f015f137-5352-48e9-8120-609639131906"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"),
                column: "PhotoNodeId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"),
                column: "PhotoNodeId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoNodeId",
                schema: "auth",
                table: "Users");
        }
    }
}
