using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class usr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "conf");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultDomainEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTypes",
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
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CredentialTypes",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrincipalEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrincipalEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PrincipalPhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrincipalPhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "C"),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplitionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ExcludeNav = table.Column<bool>(type: "bit", nullable: false),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Applications_ApplitionId",
                        column: x => x.ApplitionId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Routes_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "conf",
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CalimTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_ClaimTypes_CalimTypeId",
                        column: x => x.CalimTypeId,
                        principalSchema: "conf",
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claims_Claims_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AllowedCredentials",
                schema: "conf",
                columns: table => new
                {
                    CredentialTypeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedCredentials", x => new { x.CredentialTypeId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_AllowedCredentials_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllowedCredentials_CredentialTypes_CredentialTypeId",
                        column: x => x.CredentialTypeId,
                        principalSchema: "conf",
                        principalTable: "CredentialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CredentialTypeId = table.Column<int>(type: "int", nullable: false),
                    CredentialValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CredentialEndUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CredentialConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_CredentialTypes_CredentialTypeId",
                        column: x => x.CredentialTypeId,
                        principalSchema: "conf",
                        principalTable: "CredentialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credentials_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserApplications",
                schema: "conf",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_UserApplications", x => new { x.UserId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_UserApplications_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserApplications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRoutes",
                schema: "conf",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadClaimId = table.Column<int>(type: "int", nullable: true),
                    CreateClaimId = table.Column<int>(type: "int", nullable: true),
                    EditClaimId = table.Column<int>(type: "int", nullable: true),
                    StatusClaimId = table.Column<int>(type: "int", nullable: true),
                    DownloadClaimId = table.Column<int>(type: "int", nullable: true),
                    SpecialConditionClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoutes", x => new { x.RoleId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_CreateClaimId",
                        column: x => x.CreateClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_DownloadClaimId",
                        column: x => x.DownloadClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_EditClaimId",
                        column: x => x.EditClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_ReadClaimId",
                        column: x => x.ReadClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_SpecialConditionClaimId",
                        column: x => x.SpecialConditionClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Claims_StatusClaimId",
                        column: x => x.StatusClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "conf",
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "conf",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalSchema: "auth",
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Applications",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Central de identidad del grupo atenea", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Identity" },
                    { 2, null, new Guid("00000000-0000-0000-0000-000000000000"), "Aplicación principal de Atenea", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Iris" },
                    { 3, null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea para Asisya", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Asisya" },
                    { 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea para Promotec", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Promotec" },
                    { 5, null, new Guid("00000000-0000-0000-0000-000000000000"), "Central de datos de telefonía", null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea Asterisk" },
                    { 6, null, new Guid("00000000-0000-0000-0000-000000000000"), "Sistema de Créditos Vehiculares", null, new Guid("00000000-0000-0000-0000-000000000000"), "Oriana" },
                    { 7, null, new Guid("00000000-0000-0000-0000-000000000000"), "Sistema de financiación de seguros", null, new Guid("00000000-0000-0000-0000-000000000000"), "Finanzaseguros" },
                    { 8, null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador de credenciales de usuarios de finanzauto web", null, new Guid("00000000-0000-0000-0000-000000000000"), "Finanzauto Web Admin" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "ClaimTypes",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[] { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Claim para el acceso a un permiso especifico de la aplicación", null, new Guid("00000000-0000-0000-0000-000000000000"), "Permission" });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "CredentialTypes",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ingreso por AD bajo dominio Finanzauto", null, new Guid("00000000-0000-0000-0000-000000000000"), "FzDomain" },
                    { 2, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ingreso por AD bajo dominio Promotec", null, new Guid("00000000-0000-0000-0000-000000000000"), "PtDomain" },
                    { 3, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ingreso por ApiKey", null, new Guid("00000000-0000-0000-0000-000000000000"), "ApiKey" },
                    { 4, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ingreso por Usuario y Contaseña", null, new Guid("00000000-0000-0000-0000-000000000000"), "PassWord" },
                    { 5, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ingreso por AD bajo dominio Asisya", null, new Guid("00000000-0000-0000-0000-000000000000"), "AsDomain" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Users",
                columns: new[] { "Id", "DeletedAtUtc", "DeletedBy", "IdentificationNumber", "ModifiedAtUtc", "ModifiedBy", "Name", "PrincipalEmail", "PrincipalEmailConfirmed", "PrincipalPhoneNumber", "PrincipalPhoneNumberConfirmed", "Surname", "Username" },
                values: new object[,]
                {
                    { new Guid("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000004", null, new Guid("00000000-0000-0000-0000-000000000000"), "Johanna Andrea", "johanna.riano@finanzauto.com.co", false, "0000000004", false, "Riaño Chaparro", "johanna.riano" },
                    { new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000006", null, new Guid("00000000-0000-0000-0000-000000000000"), "Astrid", "astrid.meneses@asisya.com", false, "1000000006", false, "Meneses", "astrid.meneses" },
                    { new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000007", null, new Guid("00000000-0000-0000-0000-000000000000"), "Carlos", "carlos.molano@finanzauto.com.co", false, "0000000007", false, "Molano", "carlos.molano" },
                    { new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000000", null, new Guid("00000000-0000-0000-0000-000000000000"), "Darcy", "darcy.novoa@finanzauto.com.co", false, "0000000000", false, "Novoa", "darcy.novoa" },
                    { new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000003", null, new Guid("00000000-0000-0000-0000-000000000000"), "Laura", "laura.rueda@asisya.com", false, "1000000003", false, "Rueda", "laura.rueda" },
                    { new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1030692232", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jhon Sebastian", "jhon.cubillos@finanzauto.com.co", false, "3239336050", false, "Cubillos Gonzalez", "jhon.cubillos" },
                    { new Guid("5f7b3712-0829-4a4b-a3c5-f38f35e37ca8"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000037", null, new Guid("00000000-0000-0000-0000-000000000000"), "Carol", "carol.medina@asisya.com", false, "1000000037", false, "Medina", "carol.medina" },
                    { new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000002", null, new Guid("00000000-0000-0000-0000-000000000000"), "Elizabeth", "elizabeth.gamba@finanzauto.com.co", false, "0000000002", false, "Gamba", "elizabeth.gamba" },
                    { new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000007", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jose Willy Duvan", "jose.carrillo@asisya.com.co", false, "1000000007", false, "Carrillo Carrillo", "jose.carrillo" },
                    { new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000008", null, new Guid("00000000-0000-0000-0000-000000000000"), "Laura", "laura.roa@finanzauto.com.co", false, "3222218468", false, "Roa", "laura.roa" },
                    { new Guid("9c5a2e53-4182-4743-a36d-cf116ad3b49e"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000027", null, new Guid("00000000-0000-0000-0000-000000000000"), "Cristhian", "cristhian.lopez@asisya.com", false, "1000000027", false, "López", "cristhian.lopez" },
                    { new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000005", null, new Guid("00000000-0000-0000-0000-000000000000"), "Christian David", "christian.chilatra@finanzauto.com.co", false, "3222264771", false, "Chilatra Mendez", "christian.chilatra" },
                    { new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000000", null, new Guid("00000000-0000-0000-0000-000000000000"), "Julieth", "julieth.quinones@asisya.com", false, "1000000000", false, "Quiñiones", "julieth.quinones" },
                    { new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000006", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jeymmy Nataly", "jeymmy.camelo@finanzauto.com.co", false, "0000000006", false, "Camelo Santa", "jeymmy.camelo" },
                    { new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000001", null, new Guid("00000000-0000-0000-0000-000000000000"), "Paula", "paula.moreno@asisya.com", false, "1000000001", false, "Moreno", "paula.moreno" },
                    { new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000004", null, new Guid("00000000-0000-0000-0000-000000000000"), "Arlein", "arlein.pomar@asisya.com", false, "1000000004", false, "Pomar", "arlein.pomar" },
                    { new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000009", null, new Guid("00000000-0000-0000-0000-000000000000"), "Monica", "monica.infante@finanzauto.com.co", false, "0000000005", false, "Infante", "monica.infante" },
                    { new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000003", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jose", "jose.bernal@finanzauto.com.co", false, "0000000003", false, "Bernal", "jose.bernal" },
                    { new Guid("f015f137-5352-48e9-8120-609639131906"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000005", null, new Guid("00000000-0000-0000-0000-000000000000"), "Nicolas", "nicolas.rico@asisya.com", false, "1000000005", false, "Rico", "nicolas.rico" },
                    { new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1000000002", null, new Guid("00000000-0000-0000-0000-000000000000"), "Oscar", "oscar.vinasco@asisya.com", false, "1000000002", false, "Vinasco", "oscar.vinasco" },
                    { new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000001", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jesus", "jesus.perez@finanzauto.com.co", false, "0000000001", false, "Perez", "jesus.perez" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "AllowedCredentials",
                columns: new[] { "ApplicationId", "CredentialTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Claims",
                columns: new[] { "Id", "CalimTypeId", "DeletedAtUtc", "DeletedBy", "Description", "ModifiedAtUtc", "ModifiedBy", "ParentId", "Value" },
                values: new object[,]
                {
                    { 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver detalle clientes", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "clients:view" },
                    { 2, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Ver detalle creditos", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "credits:view" },
                    { 3, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicar creditos creditos", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "credits:create" },
                    { 4, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), "Actualizar creditos", null, new Guid("00000000-0000-0000-0000-000000000000"), null, "credits:update" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Credentials",
                columns: new[] { "Id", "CredentialEndUtc", "CredentialTypeId", "CredentialValue", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "PasswordHash", "PasswordSalt", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, "jhon.cubillos", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b") },
                    { 2, null, 2, "JCubillos", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b") },
                    { 3, null, 1, "christian.chilatra", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c") },
                    { 4, null, 1, "jesus.perez", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e") },
                    { 5, null, 1, "laura.roa", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776") },
                    { 6, null, 1, "jose.bernal", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9") },
                    { 7, null, 1, "darcy.novoa", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d") },
                    { 8, null, 1, "elizabeth.gamba", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7") },
                    { 9, null, 1, "carlos.molano", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c") },
                    { 10, null, 1, "monica.infante", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625") },
                    { 11, null, 1, "jeymmy.camelo", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6") },
                    { 12, null, 1, "johanna.riano", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7") },
                    { 13, null, 5, "jose.carrillo", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7") },
                    { 14, null, 5, "nicolas.rico", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("f015f137-5352-48e9-8120-609639131906") },
                    { 15, null, 5, "astrid.meneses", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40") },
                    { 16, null, 5, "arlein.pomar", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace") },
                    { 17, null, 5, "julieth.quinones", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3") },
                    { 18, null, 5, "laura.rueda", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d") },
                    { 19, null, 5, "paula.moreno", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220") },
                    { 20, null, 5, "oscar.vinasco", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802") },
                    { 21, null, 5, "cristhian.lopez", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("9c5a2e53-4182-4743-a36d-cf116ad3b49e") },
                    { 22, null, 5, "carol.medina", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("5f7b3712-0829-4a4b-a3c5-f38f35e37ca8") }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Agente" },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Comercial" },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 8, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin Contenido" },
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador" },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador" },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Operaciones" },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "GRC" },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 8, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Admin TI" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 1, 7, "your-requests", null, new Guid("00000000-0000-0000-0000-000000000000"), "Toda la información sobre el progreso y cualquier actualización relevante de los trámites.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Tus Solicitudes", 0, null, "/your-requests", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/3d8d9f7c0e622acad670eb3530fd6196.jfif" },
                    { 2, 7, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", 0, null, "/", "" },
                    { 3, 7, "request-client-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle e información del cliente.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle del cliente", 0, null, "/your-requests/request-client-detail/:requestId", "" },
                    { 4, 7, "credit-filing", null, new Guid("00000000-0000-0000-0000-000000000000"), "Aquí podrás radicar solicitudes y seguir sus avance paso a paso.", true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicación de crédito", 0, null, "/credit-filing", "https://www.finanzauto.info/finanzauto.finanzaseguros.api/files/76c401b9fc50c1d94bd6dbf81b85f679.jfif" },
                    { 14, 8, "externalUser", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista de usuarios externos con cambio de estado.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Usuario externos", 1, null, "/external-user", "" },
                    { 15, 8, "internalUser", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista de usuarios internos con cambio de estado y regristro.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Usuarios internos", 2, null, "/internal-user", "" },
                    { 16, 8, "", null, new Guid("00000000-0000-0000-0000-000000000000"), "", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Gestor de Contenido", 3, null, "", "" },
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
                table: "UserApplications",
                columns: new[] { "ApplicationId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { 3, new Guid("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("56313c74-d9fd-44d3-9668-c8ff502c556d"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("5f7b3712-0829-4a4b-a3c5-f38f35e37ca8"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("9c5a2e53-4182-4743-a36d-cf116ad3b49e"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("aa79dc95-724d-4eef-9744-7debd5d322a3"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("b1c48de3-2e15-4f06-a3c4-be4775936220"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("d6b042e8-2476-447e-80b4-a8c2c7b32ace"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("f015f137-5352-48e9-8120-609639131906"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("f291a98b-36da-4651-bdb5-c7f60e20d802"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("07fcaa8e-7062-4c31-b582-8285784afd68") },
                    { 2, 2, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("07fcaa8e-7062-4c31-b582-8285784afd68") },
                    { 3, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("89789f4a-570d-451d-b99b-69127421f1fe") },
                    { 4, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff") },
                    { 5, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7") }
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
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 1, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 2, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 3, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 4, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 16, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
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
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), 51, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 14, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("a4622c30-47a6-468b-a1ca-c2be50ca186d"), 15, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "Description", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 17, 8, "CarrouselImages", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para el carrousel con cambio de estado, orden, registro y detalle.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Carrusel de imagenes", 1, 16, "/carrousel-images", "" },
                    { 18, 8, "investors", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para inversionistas con cambio de estado y agregar hijos.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inversionistas", 2, 16, "/investors", "" },
                    { 19, 8, "offices", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para oficinas con cambio de estado y registro.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Oficinas", 3, 16, "/offices", "" },
                    { 20, 8, "sustainability", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para sostenibilidad .", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Sostenibilidad", 4, 16, "/sustainability", "" },
                    { 21, 8, "policies", null, new Guid("00000000-0000-0000-0000-000000000000"), "Vista gestor de contenido para polizas.", false, null, new Guid("00000000-0000-0000-0000-000000000000"), "Polizas", 5, 16, "/policies", "" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("07d4316e-4834-48fd-8afd-a96524c615ed"), new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    //{ new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("fac79991-0d25-f011-81d8-00505682eca9"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "RoleRoutes",
                columns: new[] { "RoleId", "RouteId", "CreateClaimId", "DeletedAtUtc", "DeletedBy", "DownloadClaimId", "EditClaimId", "ModifiedAtUtc", "ModifiedBy", "ReadClaimId", "SpecialConditionClaimId", "StatusClaimId" },
                values: new object[,]
                {
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 17, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 18, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 19, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 20, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("1e219934-094f-48ee-9360-2ad224160120"), 21, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedCredentials_ApplicationId",
                schema: "conf",
                table: "AllowedCredentials",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CalimTypeId_Value",
                schema: "auth",
                table: "Claims",
                columns: new[] { "CalimTypeId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ParentId",
                schema: "auth",
                table: "Claims",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_CredentialTypeId",
                schema: "auth",
                table: "Credentials",
                column: "CredentialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_CredentialValue",
                schema: "auth",
                table: "Credentials",
                column: "CredentialValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_UserId_CredentialTypeId",
                schema: "auth",
                table: "Credentials",
                columns: new[] { "UserId", "CredentialTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ClaimId",
                schema: "auth",
                table: "RoleClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId_ClaimId",
                schema: "auth",
                table: "RoleClaims",
                columns: new[] { "RoleId", "ClaimId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_CreateClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "CreateClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_DownloadClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "DownloadClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_EditClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "EditClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_ReadClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "ReadClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_RouteId",
                schema: "conf",
                table: "RoleRoutes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_SpecialConditionClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "SpecialConditionClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoutes_StatusClaimId",
                schema: "conf",
                table: "RoleRoutes",
                column: "StatusClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ApplicationId_Name",
                schema: "auth",
                table: "Roles",
                columns: new[] { "ApplicationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApplitionId_Name_Path",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name", "Path" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ParentId",
                schema: "conf",
                table: "Routes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_ApplicationId",
                schema: "conf",
                table: "UserApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ApplicationId",
                schema: "auth",
                table: "UserClaims",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ClaimId",
                schema: "auth",
                table: "UserClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId_ClaimId_ApplicationId",
                schema: "auth",
                table: "UserClaims",
                columns: new[] { "UserId", "ClaimId", "ApplicationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "auth",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentificationNumber",
                schema: "auth",
                table: "Users",
                column: "IdentificationNumber",
                unique: true,
                filter: "[IdentificationNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrincipalEmail",
                schema: "auth",
                table: "Users",
                column: "PrincipalEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrincipalPhoneNumber",
                schema: "auth",
                table: "Users",
                column: "PrincipalPhoneNumber",
                unique: true,
                filter: "[PrincipalPhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "auth",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedCredentials",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Credentials",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "RoleRoutes",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "UserApplications",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "CredentialTypes",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Claims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "ClaimTypes",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "conf");
        }
    }
}
