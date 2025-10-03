using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCarfiaoModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "conf",
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 14, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", null },
                    { 15, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", null },
                    { 16, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de usuarios", null },
                    { 17, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión de roles", null },
                    { 18, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico de gestiones", null },
                    { 19, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edición", null },
                    { 20, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Home", null }
                });

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Gestión PQRS", "Gestión PQRS" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[,]
                {
                    { 87, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.view" },
                    { 88, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.create" },
                    { 89, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.update" },
                    { 90, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.delete" },
                    { 91, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.importExport" },
                    { 92, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 14, 1, null, "cf.pqrs.review" },
                    { 93, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.view" },
                    { 94, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.create" },
                    { 95, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.update" },
                    { 96, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.delete" },
                    { 97, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes  - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.importExport" },
                    { 98, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 15, 2, null, "cf.clients.review" },
                    { 99, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.view" },
                    { 100, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.create" },
                    { 101, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.update" },
                    { 102, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.delete" },
                    { 103, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.importExport" },
                    { 104, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion usuarios - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 16, 3, null, "cf.users.review" },
                    { 105, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.view" },
                    { 106, 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.create" },
                    { 107, 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.update" },
                    { 108, 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.delete" },
                    { 109, 5, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.importExport" },
                    { 110, 6, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion roles - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 17, 4, null, "cf.roles.review" },
                    { 111, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.view" },
                    { 112, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.create" },
                    { 113, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.update" },
                    { 114, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.delete" },
                    { 115, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.importExport" },
                    { 116, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Hisotrico gestiones - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 18, 5, null, "cf.managements-history.review" },
                    { 117, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.view" },
                    { 118, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.create" },
                    { 119, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.update" },
                    { 120, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.delete" },
                    { 121, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.importExport" },
                    { 123, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Solicitudes de edicion - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 19, 6, null, "cf.requests.review" },
                    { 124, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.view" },
                    { 125, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.create" },
                    { 126, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.update" },
                    { 127, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.delete" },
                    { 128, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.importExport" },
                    { 129, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Home - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 20, 7, null, "cf.home.review" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Modules",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name", "ParentId" },
                values: new object[,]
                {
                    { 21, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS", 14 },
                    { 22, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestión PQRS", 14 },
                    { 23, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle Cliente", 15 },
                    { 24, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Información Negocio", 15 },
                    { 25, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico actualización de datos", 15 },
                    { 26, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Histórico alfasis", 15 },
                    { 27, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Información de casos", 15 },
                    { 28, 11, null, new Guid("00000000-0000-0000-0000-000000000000"), "", null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes", 15 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "ActionId", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ModuleId", "Order", "ParentId", "Value" },
                values: new object[,]
                {
                    { 130, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.view" },
                    { 131, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.create" },
                    { 132, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.update" },
                    { 133, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.delete" },
                    { 134, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.importExport" },
                    { 135, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar PQRS - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 21, 1, null, "cf.pqrs.file.review" },
                    { 136, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.view" },
                    { 137, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.create" },
                    { 138, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.update" },
                    { 139, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.delete" },
                    { 140, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.importExport" },
                    { 141, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestion PQRS - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 22, 2, null, "cf.pqrs.management.review" },
                    { 142, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.view" },
                    { 143, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.create" },
                    { 144, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.update" },
                    { 145, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.delete" },
                    { 146, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.importExport" },
                    { 147, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Deatlle Cliente - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 23, 1, null, "cf.clients.detail.review" },
                    { 148, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.view" },
                    { 149, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.create" },
                    { 150, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.update" },
                    { 151, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.delete" },
                    { 152, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.importExport" },
                    { 153, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Informacion negocio - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 24, 2, null, "cf.clients.business-info.review" },
                    { 154, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.view" },
                    { 155, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.create" },
                    { 156, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.update" },
                    { 157, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.delete" },
                    { 158, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.importExport" },
                    { 159, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico actualizacion de datos - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 25, 3, null, "cf.clients.update-history.review" },
                    { 160, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.view" },
                    { 161, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.create" },
                    { 162, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.update" },
                    { 163, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.delete" },
                    { 164, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.importExport" },
                    { 165, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Historico alfasis - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 26, 4, null, "cf.clients.alfasis-history.review" },
                    { 166, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.view" },
                    { 167, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.create" },
                    { 168, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.update" },
                    { 169, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.delete" },
                    { 170, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.importExport" },
                    { 171, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Infromacion de casos - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 27, 5, null, "cf.clients.case-info.review" },
                    { 172, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - ver", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.view" },
                    { 173, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - crear", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.create" },
                    { 174, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - editar", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.update" },
                    { 175, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - eliminar", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.delete" },
                    { 176, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - descargar/cargar", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.importExport" },
                    { 177, 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Clientes - aprobar/negar", null, new Guid("00000000-0000-0000-0000-000000000000"), 28, 6, null, "cf.sub-clients.review" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "RoleId" },
                values: new object[,]
                {
                    { 6, 87, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 7, 88, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 8, 89, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 9, 90, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 10, 91, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 11, 92, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 12, 93, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 13, 94, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 14, 95, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 15, 96, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 16, 97, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 17, 98, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 18, 99, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 19, 100, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 20, 101, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 21, 102, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 22, 103, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 23, 104, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 24, 105, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 25, 106, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 26, 107, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 27, 108, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 28, 109, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 29, 110, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 30, 111, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 31, 112, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 32, 113, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 33, 114, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 34, 115, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 35, 116, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 36, 117, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 37, 118, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 38, 119, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 39, 120, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 40, 121, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 41, 123, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 42, 124, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 43, 125, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 44, 126, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 45, 127, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 46, 128, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 47, 129, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 48, 130, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 49, 131, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 50, 132, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 51, 133, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 52, 134, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 53, 135, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 54, 136, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 55, 137, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 56, 138, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 57, 139, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 58, 140, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 59, 141, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 60, 142, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 61, 143, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 62, 144, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 63, 145, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 64, 146, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 65, 147, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 66, 148, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 67, 149, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 68, 150, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 69, 151, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 70, 152, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 71, 153, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 72, 154, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 73, 155, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 74, 156, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 75, 157, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 76, 158, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 77, 159, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 78, 160, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 79, 161, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 80, 162, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 81, 163, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 82, 164, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 83, 165, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 84, 166, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 85, 167, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 86, 168, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 87, 169, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 88, 170, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 89, 171, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 90, 172, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 91, 173, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 92, 174, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 93, 175, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 94, 176, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") },
                    { 95, 177, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bc59a574-4972-41d7-92a9-fdfbef4aad8a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "conf",
                table: "Modules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                schema: "conf",
                table: "Routes",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Gestion PQRS", "Gestion PQRS" });
        }
    }
}
