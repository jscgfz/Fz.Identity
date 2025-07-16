using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddModulesAndActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                schema: "auth",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                schema: "auth",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actions",
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
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modules_Modules_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "conf",
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Actions",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver" },
                    { 2, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear" },
                    { 3, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Modificar" },
                    { 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Eliminar" },
                    { 5, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Descargar/Cargar" },
                    { 6, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Aprobar/Negar" }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActionId", "ModuleId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActionId", "ModuleId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActionId", "ModuleId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActionId", "ModuleId" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", null },
                    { 2, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", null },
                    { 3, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", null },
                    { 4, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Soliciitudes de edición", null }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "ParentId", "Value" },
                values: new object[,]
                {
                    { 5, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.view" },
                    { 6, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.create" },
                    { 7, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Actualizar usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.update" },
                    { 8, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Eliminar usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.delete" },
                    { 9, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Descargar/Cargar usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.importExport" },
                    { 10, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aprobar/Negar usuarios", null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "users.review" },
                    { 11, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.view" },
                    { 12, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.create" },
                    { 13, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Actualizar roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.update" },
                    { 14, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Eliminar roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.delete" },
                    { 15, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Descargar/Cargar roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.importExport" },
                    { 16, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aprobar/Negar roles", null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, "roles.review" },
                    { 17, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.view" },
                    { 18, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.create" },
                    { 19, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Actualizar gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.update" },
                    { 20, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Eliminar gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.delete" },
                    { 21, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Descargar/Cargar gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.importExport" },
                    { 22, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aprobar/Negar gestiones", null, new Guid("00000000-0000-0000-0000-000000000000"), 3, null, "managements.review" },
                    { 23, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.view" },
                    { 24, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Crear solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.create" },
                    { 25, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Actualizar solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.update" },
                    { 26, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Eliminar solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.delete" },
                    { 27, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Descargar/Cargar solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.importExport" },
                    { 28, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aprobar/Negar solicitudes", null, new Guid("00000000-0000-0000-0000-000000000000"), 4, null, "requests.review" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ActionId",
                schema: "auth",
                table: "Claims",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ModuleId",
                schema: "auth",
                table: "Claims",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ApplicationId",
                schema: "conf",
                table: "Modules",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ParentId",
                schema: "conf",
                table: "Modules",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Actions_ActionId",
                schema: "auth",
                table: "Claims",
                column: "ActionId",
                principalSchema: "conf",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Modules_ModuleId",
                schema: "auth",
                table: "Claims",
                column: "ModuleId",
                principalSchema: "conf",
                principalTable: "Modules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Actions_ActionId",
                schema: "auth",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Modules_ModuleId",
                schema: "auth",
                table: "Claims");

            migrationBuilder.DropTable(
                name: "Actions",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "conf");

            migrationBuilder.DropIndex(
                name: "IX_Claims_ActionId",
                schema: "auth",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_ModuleId",
                schema: "auth",
                table: "Claims");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DropColumn(
                name: "ActionId",
                schema: "auth",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                schema: "auth",
                table: "Claims");
        }
    }
}
