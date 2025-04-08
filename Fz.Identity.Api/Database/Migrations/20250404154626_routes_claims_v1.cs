using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fz.Identity.Api.Database.Migrations
{
  /// <inheritdoc />
  public partial class routes_claims_v1 : Migration
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
                    IdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrincipalEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrincipalEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PrincipalPhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrincipalPhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
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
                    UrlImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 7, null, new Guid("00000000-0000-0000-0000-000000000000"), "Sistema de financiación de seguros", null, new Guid("00000000-0000-0000-0000-000000000000"), "Finanzaseguros" }
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
                    { new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000007", null, new Guid("00000000-0000-0000-0000-000000000000"), "Carlos", "carlos.molano@finanzauto.com.co", false, "0000000007", false, "Molano", "carlos.molano" },
                    { new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000000", null, new Guid("00000000-0000-0000-0000-000000000000"), "Darcy", "darcy.novoa@finanzauto.com.co", false, "0000000000", false, "Novoa", "darcy.novoa" },
                    { new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), "1030692232", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jhon Sebastian", "jhon.cubillos@finanzauto.com.co", false, "3239336050", false, "Cubillos Gonzalez", "jhon.cubillos" },
                    { new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000002", null, new Guid("00000000-0000-0000-0000-000000000000"), "Elizabeth", "elizabeth.gamba@finanzauto.com.co", false, "0000000002", false, "Gamba", "elizabeth.gamba" },
                    { new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000008", null, new Guid("00000000-0000-0000-0000-000000000000"), "Laura", "laura.roa@finanzauto.com.co", false, "3222218468", false, "Roa", "laura.roa" },
                    { new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000005", null, new Guid("00000000-0000-0000-0000-000000000000"), "Christian David", "christian.chilatra@finanzauto.com.co", false, "3222264771", false, "Chilatra Mendez", "christian.chilatra" },
                    { new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000006", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jeymmy Nataly", "jeymmy.camelo@finanzauto.com.co", false, "0000000006", false, "Camelo Santa", "jeymmy.camelo" },
                    { new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000009", null, new Guid("00000000-0000-0000-0000-000000000000"), "Monica", "monica.infante@finanzauto.com.co", false, "0000000005", false, "Infante", "monica.infante" },
                    { new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9"), null, new Guid("00000000-0000-0000-0000-000000000000"), "0000000003", null, new Guid("00000000-0000-0000-0000-000000000000"), "Jose", "jose.bernal@finanzauto.com.co", false, "0000000003", false, "Bernal", "jose.bernal" },
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
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 3 },
                    { 5, 3 }
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
                columns: new[] { "Id", "CredentialEndUtc", "CredentialTypeId", "CredentialValue", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, "{\"Username\":\"jhon.cubillos\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b") },
                    { 2, null, 2, "{\"Username\":\"JCubillos\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b") },
                    { 3, null, 1, "{\"Username\":\"christian.chilatra\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c") },
                    { 4, null, 1, "{\"Username\":\"jesus.perez\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e") },
                    { 5, null, 1, "{\"Username\":\"laura.roa\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776") },
                    { 6, null, 1, "{\"Username\":\"jose.bernal\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e81ccb87-d2e0-4609-8d0b-63989625c7e9") },
                    { 7, null, 1, "{\"Username\":\"darcy.novoa\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("3181c2ed-7454-4c71-99a9-0797daa0f32d") },
                    { 8, null, 1, "{\"Username\":\"elizabeth.gamba\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("71e13750-87bb-40a7-bb93-58e8f603b1a7") },
                    { 9, null, 1, "{\"Username\":\"carlos.molano\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("134ab661-2928-44e8-9e0c-b96d70e8164c") },
                    { 10, null, 1, "{\"Username\":\"monica.infante\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("d7d52b73-842a-4e8f-a090-f5c4a22fe625") },
                    { 11, null, 1, "{\"Username\":\"jeymmy.camelo\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aae0504e-8145-461f-a7ab-9f9621e387d6") },
                    { 12, null, 1, "{\"Username\":\"johanna.riano\"}", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("0622f38d-f7c9-41a2-9b80-7f77ea6ba7d7") }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ApplicationId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Comercial" },
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Administrador" },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "Operaciones" },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), 7, null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), "GRC" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Routes",
                columns: new[] { "Id", "ApplitionId", "Component", "DeletedAtUtc", "DeletedBy", "ExcludeNav", "ModifiedAtUtc", "ModifiedBy", "Name", "Order", "ParentId", "Path", "UrlImg" },
                values: new object[,]
                {
                    { 1, 7, "your-requests", null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Tus Solicitudes", 0, null, "/your-requests", "" },
                    { 2, 7, "home", null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Inicio", 0, null, "/", "" },
                    { 3, 7, "request-client-detail", null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Detalle del cliente", 0, null, "/your-requests/request-client-detail/:requestId", "" },
                    { 4, 7, "credit-filing", null, new Guid("00000000-0000-0000-0000-000000000000"), true, null, new Guid("00000000-0000-0000-0000-000000000000"), "Radicación de crédito", 0, null, "/credit-filing", "" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "UserApplications",
                columns: new[] { "ApplicationId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { 7, new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
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
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 1, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 2, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 3, null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), 1, null, null },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), 4, 3, null, new Guid("00000000-0000-0000-0000-000000000000"), null, 4, null, new Guid("00000000-0000-0000-0000-000000000000"), 2, null, null }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("228ee2e2-843e-47cc-98ff-ae78e52340b7"), new Guid("5ea12c28-b655-41e6-be6c-ed56c781d30b"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), new Guid("8d7e4c06-16d7-4448-b145-bda5f1af0776"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("89789f4a-570d-451d-b99b-69127421f1fe"), new Guid("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("07fcaa8e-7062-4c31-b582-8285784afd68"), new Guid("f465489e-f743-40c2-8585-3ebdc982ac5e"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") }
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
                name: "IX_Routes_ApplitionId_Name",
                schema: "conf",
                table: "Routes",
                columns: new[] { "ApplitionId", "Name" },
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
                unique: true);

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
                unique: true);

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
