using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AteneaPtConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Routes_ApplitionId_Name",
                schema: "conf",
                table: "Routes");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "conf",
                table: "Routes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Agente" },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 22, 4, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", 0, null, "/", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 23, 4, "pqrs-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", 0, null, "/pqrs-management", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 24, 4, "call-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión llamadas", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión llamadas", 0, null, "/call-management", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 25, 4, "clients", null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", 0, null, "/clients", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 26, 4, "agent-manager", null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Agentes", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Agentes", 0, null, "/agent-manager", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 27, 4, "whatsapp", null, new Guid("00000000-0000-0000-0000-000000000000"), "WhatsApp", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "WhatsApp", 0, null, "/whatsapp", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 28, 4, "communications-manager", null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Comunicaciones", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Comunicaciones", 0, null, "/communications-manager0", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 29, 4, "historical", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico", 0, null, "/historical", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 30, 4, "reports", null, new Guid("00000000-0000-0000-0000-000000000000"), "Informes", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informes", 0, null, "/reports", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 31, 4, "pqrs-summary", null, new Guid("00000000-0000-0000-0000-000000000000"), "Resumen de caso PQRS", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Resumen de caso PQRS", 0, null, "/pqrs-management/pqrs-summary/:caseTypeId", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 32, 4, "pqrs-management-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de caso NO.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de caso NO.", 0, null, "/pqrs-management/pqrs-detail/:pqrsId", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 33, 4, "file-pqrs", null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", 0, null, "/pqrs-management/file-pqrs", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 34, 4, "client-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de Cliente", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle de Cliente", 0, null, "/client/client-detail/:clientId", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 40, 4, "agent-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle Agente", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle Agente", 0, null, "/agent-manager/agent-detail/:agentName", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 41, 4, "calendar", null, new Guid("00000000-0000-0000-0000-000000000000"), "Calendario", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Calendario", 0, null, "/calendar", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 45, 4, "email", null, new Guid("00000000-0000-0000-0000-000000000000"), "Correos", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Correos", 0, null, "/email", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 46, 4, "user-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 0, null, "/user-management", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 47, 4, "role-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", 0, null, "/role-management", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 48, 4, "history-management", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", 0, null, "/history-management", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 49, 4, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 0, null, "/user-management/create-user", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 50, 4, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 0, null, "/user-management/edit-user/:id", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 51, 4, "actions-user", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", 0, null, "/user-management/view-user/:id", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 22, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 23, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 24, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 25, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 26, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 27, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 28, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 40, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 45, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 46, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 22, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 23, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 24, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 25, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 26, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 27, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 28, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 40, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 45, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 46, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 51, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("fac79991-0d25-f011-81d8-00505682eca9"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApplitionId_Name_Path",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name", "Path" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Routes_ApplitionId_Name_Path",
                schema: "conf",
                table: "Routes");

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 22 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 23 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 24 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 25 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 26 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 27 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 28 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 40 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 45 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 46 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 22 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 23 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 24 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 25 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 26 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 27 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 28 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 40 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 45 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 46 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "RoleRoutes",
                keyColumns: new[] { "RoleId", "RouteId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 51 });

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d") });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7") });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776") });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("fac79991-0d25-f011-81d8-00505682eca9") });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"));

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "conf",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApplitionId_Name",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name" },
                unique: true);
        }
    }
}
