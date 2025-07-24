using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessedByRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProcessedBy",
                schema: "conf",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessedBy",
                schema: "conf",
                table: "Requests");
        }
    }
}
