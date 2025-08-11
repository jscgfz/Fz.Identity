using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveDirecotryRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 74 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 75 });

            migrationBuilder.DropColumn(
                name: "ActiveDirectoryName",
                schema: "auth",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                schema: "conf",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActiveDirectoryRoles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveDirectoryRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveDirectoryRoles_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "ActiveDirectoryRoles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("103a9658-d288-4192-adb6-e139993c4121"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Analista" },
                    { new Guid("1635c724-2c22-40b8-80e8-01b5da129dba"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_TI" },
                    { new Guid("1ff15957-dc97-4618-9a60-00ba9058a171"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_SI" },
                    { new Guid("3483abb2-e44d-4851-bab5-19ba06746062"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Auditor" },
                    { new Guid("3fee3a4e-6ada-482a-aa70-7aba3d1e3e2c"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Coordinador" },
                    { new Guid("5b3c8352-3390-4d72-8be6-914548f455cb"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Lider_SIAR" },
                    { new Guid("821fb971-75b9-44cf-b703-d4e2442fd614"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Analista_Calidad" },
                    { new Guid("919163a2-ebd1-4b10-8d84-ba98568cbef7"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Asistente" },
                    { new Guid("a9e40a8e-2420-43de-9abb-fcb4cf327d37"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Lider_Calidad" },
                    { new Guid("d9965f5b-0c20-40c5-94a7-e508f8a88e0a"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "APT_Area" }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Alias",
                value: null);

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
                keyValue: 5,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Alias",
                value: null);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                column: "Alias",
                value: null);

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 46, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 47, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 48, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 51, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22526b31-4f44-4775-b5b4-6b07005dda60"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2513a3ec-519a-437c-9f47-d3ed69b5cd06"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89789f4a-570d-451d-b99b-69127421f1fe"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"),
                column: "ActiveDirectoryRoleId",
                value: new Guid("1ff15957-dc97-4618-9a60-00ba9058a171"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d525cf87-3c00-48dc-992d-284d2a12772f"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"),
                column: "ActiveDirectoryRoleId",
                value: null);

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ActiveDirectoryRoleId", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), new Guid("d9965f5b-0c20-40c5-94a7-e508f8a88e0a"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Área" },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), new Guid("1635c724-2c22-40b8-80e8-01b5da129dba"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "T.I" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 23, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 31, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 32, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 46, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 47, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 48, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 49, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 50, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 51, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 73, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 74, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 75, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles",
                column: "ActiveDirectoryRoleId",
                unique: true,
                filter: "[ActiveDirectoryRoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveDirectoryRoles_ApplicationId",
                schema: "auth",
                table: "ActiveDirectoryRoles",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActiveDirectoryRoles_ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles",
                column: "ActiveDirectoryRoleId",
                principalSchema: "auth",
                principalTable: "ActiveDirectoryRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActiveDirectoryRoles_ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "ActiveDirectoryRoles",
                schema: "auth");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles");

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 23 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 31 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66551899-cf82-4548-8c4b-052745d2869a"), 32 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 46 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 47 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 48 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 49 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 50 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 51 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 73 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 74 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("66818ace-8c12-4588-be9a-0343922e7623"), 75 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 46 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 47 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 48 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 51 });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66551899-cf82-4548-8c4b-052745d2869a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66818ace-8c12-4588-be9a-0343922e7623"));

            migrationBuilder.DropColumn(
                name: "ActiveDirectoryRoleId",
                schema: "auth",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Alias",
                schema: "conf",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ActiveDirectoryName",
                schema: "auth",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 74, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"), 75, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0085e762-9a41-4867-942a-0e1b3f892e3f"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1e219934-094f-48ee-9360-2ad224160120"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22526b31-4f44-4775-b5b4-6b07005dda60"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2513a3ec-519a-437c-9f47-d3ed69b5cd06"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79dfb3c0-05c5-40c0-93f5-a9a8984deed4"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89789f4a-570d-451d-b99b-69127421f1fe"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9b9d01c9-9ec8-46ae-8030-62112e045ea4"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1b62929-957c-4ee6-a02c-dd0aee3555ee"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b3bb793d-4386-4f98-bcc0-c3844f61c9e3"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d502d91b-7514-4e87-81e5-173584c7bd4a"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d525cf87-3c00-48dc-992d-284d2a12772f"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ded75b0d-570d-4687-ba95-e9348d29e37e"),
                column: "ActiveDirectoryName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e8a76b3f-c104-4d69-a6ec-18a392bfcaa5"),
                column: "ActiveDirectoryName",
                value: null);
        }
    }
}
