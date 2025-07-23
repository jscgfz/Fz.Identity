using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.Identity.Api.Database.Migrations.Identity
{
    /// <inheritdoc />
    public partial class InitialConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.EnsureSchema(
                name: "conf");

            migrationBuilder.EnsureSchema(
                name: "sec");

            migrationBuilder.EnsureSchema(
                name: "id");

            migrationBuilder.CreateTable(
                name: "Apps",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AppIndex = table.Column<int>(type: "int", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MultiDomainEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RootApplicationEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimActions",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimSections",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HigherOrderEndpoints",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Method = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequiresSecondAuthLayer = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RequiresThirdAuthLayer = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherOrderEndpoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HigherOrderOrigins",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    SignatureKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherOrderOrigins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginTypes",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticationType = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "conf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExcludeNav = table.Column<bool>(type: "bit", nullable: false),
                    Component = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "id",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DocumentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeys",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Consumer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApiKeyHash = table.Column<byte[]>(type: "varbinary(900)", nullable: false),
                    ApiKeySalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiKeys_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppSafety",
                schema: "conf",
                columns: table => new
                {
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SignautreKey = table.Column<byte[]>(type: "varbinary(900)", nullable: false),
                    ExpirationTime = table.Column<TimeSpan>(type: "time", nullable: false, defaultValue: new TimeSpan(0, 2, 0, 0, 0)),
                    RefreshExpirationTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSafety", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_AppSafety_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "id",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClaimValues",
                schema: "sec",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ClaimSectionId = table.Column<int>(type: "int", nullable: false),
                    ClaimActionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimValues_ClaimActions_ClaimActionId",
                        column: x => x.ClaimActionId,
                        principalSchema: "sec",
                        principalTable: "ClaimActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimValues_ClaimSections_ClaimSectionId",
                        column: x => x.ClaimSectionId,
                        principalSchema: "sec",
                        principalTable: "ClaimSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HigherOrderEndpointOrigins",
                schema: "sec",
                columns: table => new
                {
                    EndpointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HigherOrderEndpointOrigins", x => new { x.EndpointId, x.KeyId });
                    table.ForeignKey(
                        name: "FK_HigherOrderEndpointOrigins_HigherOrderEndpoints_EndpointId",
                        column: x => x.EndpointId,
                        principalSchema: "sec",
                        principalTable: "HigherOrderEndpoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HigherOrderEndpointOrigins_HigherOrderOrigins_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "sec",
                        principalTable: "HigherOrderOrigins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoginApps",
                schema: "conf",
                columns: table => new
                {
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginApps", x => new { x.AppId, x.LoginTypeId });
                    table.ForeignKey(
                        name: "FK_LoginApps_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoginApps_LoginTypes_LoginTypeId",
                        column: x => x.LoginTypeId,
                        principalSchema: "sec",
                        principalTable: "LoginTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                schema: "id",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "id",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DomainCredentials",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginTypeId = table.Column<int>(type: "int", nullable: false),
                    LoginConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LoginExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainCredentials_LoginTypes_LoginTypeId",
                        column: x => x.LoginTypeId,
                        principalSchema: "sec",
                        principalTable: "LoginTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "id",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SingleCredentials",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleCredentials", x => new { x.UserId, x.AppId });
                    table.ForeignKey(
                        name: "FK_SingleCredentials_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SingleCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "id",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleRoute",
                schema: "auth",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoute", x => new { x.RoleId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_RoleRoute_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "id",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleRoute_Routes_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "conf",
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "sec",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "id",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "id",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApiKeyClaims",
                schema: "auth",
                columns: table => new
                {
                    ApiKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeyClaims", x => new { x.ApiKeyId, x.ClaimValueId });
                    table.ForeignKey(
                        name: "FK_ApiKeyClaims_ApiKeys_ApiKeyId",
                        column: x => x.ApiKeyId,
                        principalSchema: "auth",
                        principalTable: "ApiKeys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApiKeyClaims_ClaimValues_ClaimValueId",
                        column: x => x.ClaimValueId,
                        principalSchema: "sec",
                        principalTable: "ClaimValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "auth",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => new { x.RoleId, x.ClaimValueId });
                    table.ForeignKey(
                        name: "FK_RoleClaims_ClaimValues_ClaimValueId",
                        column: x => x.ClaimValueId,
                        principalSchema: "sec",
                        principalTable: "ClaimValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "id",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => new { x.UserId, x.ClaimValueId, x.AppId });
                    table.ForeignKey(
                        name: "FK_UserClaims_Apps_AppId",
                        column: x => x.AppId,
                        principalSchema: "conf",
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaims_ClaimValues_ClaimValueId",
                        column: x => x.ClaimValueId,
                        principalSchema: "sec",
                        principalTable: "ClaimValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "id",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "AppSettings",
                columns: new[] { "Id", "CreatedBy", "DeletedAtUtc", "DeletedBy", "LastModifiedAtUtc", "LastModifiedBy", "Value" },
                values: new object[,]
                {
                    { "DomainAuthenticationSettings:BaseUrl", null, null, null, null, null, "http://www.qdatacolombia.com/Services/ServiciosApi/ServiceAutenticacionLDAP" },
                    { "JsonWebTokenSettings:RefreshTokenExpirationTime", null, null, null, null, null, "03:00:00" },
                    { "JsonWebTokenSettings:TokenExpirationTime", null, null, null, null, null, "01:00:00" },
                    { "OtpSettings:AlloweCharacters", null, null, null, null, null, "0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ" },
                    { "OtpSettings:OtpExpiration", null, null, null, null, null, "00:10:00" },
                    { "OtpSettings:OtpLength", null, null, null, null, null, "8" },
                    { "PasswordGenerationSettings:AlloWedCharacters:0", null, null, null, null, null, "!" },
                    { "PasswordGenerationSettings:AlloWedCharacters:1", null, null, null, null, null, "#" },
                    { "PasswordGenerationSettings:AlloWedCharacters:10", null, null, null, null, null, "¡" },
                    { "PasswordGenerationSettings:AlloWedCharacters:11", null, null, null, null, null, "*" },
                    { "PasswordGenerationSettings:AlloWedCharacters:12", null, null, null, null, null, "+" },
                    { "PasswordGenerationSettings:AlloWedCharacters:13", null, null, null, null, null, "-" },
                    { "PasswordGenerationSettings:AlloWedCharacters:14", null, null, null, null, null, "_" },
                    { "PasswordGenerationSettings:AlloWedCharacters:15", null, null, null, null, null, "." },
                    { "PasswordGenerationSettings:AlloWedCharacters:16", null, null, null, null, null, ":" },
                    { "PasswordGenerationSettings:AlloWedCharacters:17", null, null, null, null, null, "," },
                    { "PasswordGenerationSettings:AlloWedCharacters:18", null, null, null, null, null, ";" },
                    { "PasswordGenerationSettings:AlloWedCharacters:19", null, null, null, null, null, "{" },
                    { "PasswordGenerationSettings:AlloWedCharacters:2", null, null, null, null, null, "$" },
                    { "PasswordGenerationSettings:AlloWedCharacters:20", null, null, null, null, null, "}" },
                    { "PasswordGenerationSettings:AlloWedCharacters:21", null, null, null, null, null, "[" },
                    { "PasswordGenerationSettings:AlloWedCharacters:22", null, null, null, null, null, "]" },
                    { "PasswordGenerationSettings:AlloWedCharacters:23", null, null, null, null, null, "~" },
                    { "PasswordGenerationSettings:AlloWedCharacters:24", null, null, null, null, null, "\\" },
                    { "PasswordGenerationSettings:AlloWedCharacters:3", null, null, null, null, null, "%" },
                    { "PasswordGenerationSettings:AlloWedCharacters:4", null, null, null, null, null, "&" },
                    { "PasswordGenerationSettings:AlloWedCharacters:5", null, null, null, null, null, "/" },
                    { "PasswordGenerationSettings:AlloWedCharacters:6", null, null, null, null, null, "(" },
                    { "PasswordGenerationSettings:AlloWedCharacters:7", null, null, null, null, null, ")" },
                    { "PasswordGenerationSettings:AlloWedCharacters:8", null, null, null, null, null, "=" },
                    { "PasswordGenerationSettings:AlloWedCharacters:9", null, null, null, null, null, "?" },
                    { "PasswordGenerationSettings:MinimunLength", null, null, null, null, null, "10" },
                    { "PasswordGenerationSettings:RequiresLowerCase", null, null, null, null, null, "True" },
                    { "PasswordGenerationSettings:RequiresNumbers", null, null, null, null, null, "True" },
                    { "PasswordGenerationSettings:RequiresSpecialCharacters", null, null, null, null, null, "False" },
                    { "PasswordGenerationSettings:RequiresUpperCase", null, null, null, null, null, "True" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "ClaimActions",
                columns: new[] { "Id", "CreatedBy", "DeletedAtUtc", "DeletedBy", "Description", "LastModifiedAtUtc", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, "Permisos relacionados al control de usuarios", null, null, "users" },
                    { 2, null, null, null, "Permisos relacionados al control de roles", null, null, "roles" },
                    { 3, null, null, null, "Permisos relacionados al control de rutas", null, null, "routes" },
                    { 4, null, null, null, "Permisos relacionados al control de api keys", null, null, "apikeys" },
                    { 5, null, null, null, "Permisos relacionados al control de credenciales", null, null, "credentials" },
                    { 6, null, null, null, "Permisos relacionados al control de aplicaciones", null, null, "apps" },
                    { 7, null, null, null, "Permisos relacionados al control de endpoints de orden superior", null, null, "endpoints" },
                    { 8, null, null, null, "Permisos relacionados al control de llamadas", null, null, "calls" },
                    { 9, null, null, null, "Permisos relacionados al control de ajustes del sistema", null, null, "config" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "ClaimSections",
                columns: new[] { "Id", "CreatedBy", "DeletedAtUtc", "DeletedBy", "Description", "LastModifiedAtUtc", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, "Permisos relacionados a la lectura de datos", null, null, "read" },
                    { 2, null, null, null, "Permisos relacionados a la creaci�n de datos", null, null, "create" },
                    { 3, null, null, null, "Permisos relacionados a la modificaci�n de datos", null, null, "modify" },
                    { 4, null, null, null, "Permisos relacionados a la eliminaci�n de datos", null, null, "delete" },
                    { 5, null, null, null, "Permisos relacionados a la escucha de grabaciones", null, null, "listen" },
                    { 6, null, null, null, "Permisos relacionados a la descarga de datos", null, null, "download" },
                    { 7, null, null, null, "Permisos relacionados al acceso a datos de seguridad", null, null, "security" },
                    { 8, null, null, null, "Permisos relacionados a la carga de datos", null, null, "upload" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "LoginTypes",
                columns: new[] { "Id", "AuthenticationType", "CreatedBy", "DeletedAtUtc", "DeletedBy", "Description", "DomainName", "Key", "LastModifiedAtUtc", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 2, null, null, null, "Login using a FZCORP credential", "FZCORP", "KdNESJeIadQ+U+Q5Qs+8BQ==", null, null, "Finanzauto" },
                    { 2, 2, null, null, null, "Login using a QBTA credential", "QBTA", "KdNESJeIadQ+U+Q5Qs+8BQ==", null, null, "Quantum Data" },
                    { 3, 2, null, null, null, "Login using a PTSEGUROS credential", "PTSEGUROS", "KdNESJeIadQ+U+Q5Qs+8BQ==", null, null, "Promotec" },
                    { 4, 2, null, null, null, "Login using a FZCORP credential", "FZCORP", "KdNESJeIadQ+U+Q5Qs+8BQ==", null, null, "Control Next" },
                    { 5, 2, null, null, null, "Login using a ASISYA credential", "FZCORP", "SWJF7E+6Grf63Co9Djy2Jw==", null, null, "Asisya" },
                    { 6, 1, null, null, null, "Login using a user and password", null, null, null, null, "User-Password" }
                });

            migrationBuilder.InsertData(
                schema: "sec",
                table: "ClaimValues",
                columns: new[] { "Id", "ClaimActionId", "ClaimSectionId", "CreatedBy", "DeletedAtUtc", "DeletedBy", "LastModifiedAtUtc", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("192140f7-3167-f011-81dc-00505682eca9"), 1, 1, null, null, null, null, null },
                    { new Guid("1a2140f7-3167-f011-81dc-00505682eca9"), 2, 1, null, null, null, null, null },
                    { new Guid("1b2140f7-3167-f011-81dc-00505682eca9"), 3, 1, null, null, null, null, null },
                    { new Guid("1c2140f7-3167-f011-81dc-00505682eca9"), 4, 1, null, null, null, null, null },
                    { new Guid("1d2140f7-3167-f011-81dc-00505682eca9"), 5, 1, null, null, null, null, null },
                    { new Guid("1e2140f7-3167-f011-81dc-00505682eca9"), 6, 1, null, null, null, null, null },
                    { new Guid("1f2140f7-3167-f011-81dc-00505682eca9"), 7, 1, null, null, null, null, null },
                    { new Guid("202140f7-3167-f011-81dc-00505682eca9"), 8, 1, null, null, null, null, null },
                    { new Guid("212140f7-3167-f011-81dc-00505682eca9"), 9, 1, null, null, null, null, null },
                    { new Guid("222140f7-3167-f011-81dc-00505682eca9"), 1, 2, null, null, null, null, null },
                    { new Guid("232140f7-3167-f011-81dc-00505682eca9"), 2, 2, null, null, null, null, null },
                    { new Guid("242140f7-3167-f011-81dc-00505682eca9"), 3, 2, null, null, null, null, null },
                    { new Guid("252140f7-3167-f011-81dc-00505682eca9"), 4, 2, null, null, null, null, null },
                    { new Guid("262140f7-3167-f011-81dc-00505682eca9"), 5, 2, null, null, null, null, null },
                    { new Guid("272140f7-3167-f011-81dc-00505682eca9"), 6, 2, null, null, null, null, null },
                    { new Guid("282140f7-3167-f011-81dc-00505682eca9"), 7, 2, null, null, null, null, null },
                    { new Guid("292140f7-3167-f011-81dc-00505682eca9"), 8, 2, null, null, null, null, null },
                    { new Guid("2a2140f7-3167-f011-81dc-00505682eca9"), 9, 2, null, null, null, null, null },
                    { new Guid("2b2140f7-3167-f011-81dc-00505682eca9"), 1, 3, null, null, null, null, null },
                    { new Guid("2c2140f7-3167-f011-81dc-00505682eca9"), 2, 3, null, null, null, null, null },
                    { new Guid("2d2140f7-3167-f011-81dc-00505682eca9"), 3, 3, null, null, null, null, null },
                    { new Guid("2e2140f7-3167-f011-81dc-00505682eca9"), 4, 3, null, null, null, null, null },
                    { new Guid("2f2140f7-3167-f011-81dc-00505682eca9"), 5, 3, null, null, null, null, null },
                    { new Guid("302140f7-3167-f011-81dc-00505682eca9"), 6, 3, null, null, null, null, null },
                    { new Guid("312140f7-3167-f011-81dc-00505682eca9"), 7, 3, null, null, null, null, null },
                    { new Guid("322140f7-3167-f011-81dc-00505682eca9"), 8, 3, null, null, null, null, null },
                    { new Guid("332140f7-3167-f011-81dc-00505682eca9"), 9, 3, null, null, null, null, null },
                    { new Guid("342140f7-3167-f011-81dc-00505682eca9"), 1, 4, null, null, null, null, null },
                    { new Guid("352140f7-3167-f011-81dc-00505682eca9"), 2, 4, null, null, null, null, null },
                    { new Guid("362140f7-3167-f011-81dc-00505682eca9"), 3, 4, null, null, null, null, null },
                    { new Guid("372140f7-3167-f011-81dc-00505682eca9"), 4, 4, null, null, null, null, null },
                    { new Guid("382140f7-3167-f011-81dc-00505682eca9"), 5, 4, null, null, null, null, null },
                    { new Guid("392140f7-3167-f011-81dc-00505682eca9"), 6, 4, null, null, null, null, null },
                    { new Guid("3a2140f7-3167-f011-81dc-00505682eca9"), 7, 4, null, null, null, null, null },
                    { new Guid("3b2140f7-3167-f011-81dc-00505682eca9"), 8, 4, null, null, null, null, null },
                    { new Guid("3c2140f7-3167-f011-81dc-00505682eca9"), 9, 4, null, null, null, null, null },
                    { new Guid("3d2140f7-3167-f011-81dc-00505682eca9"), 1, 5, null, null, null, null, null },
                    { new Guid("3e2140f7-3167-f011-81dc-00505682eca9"), 2, 5, null, null, null, null, null },
                    { new Guid("3f2140f7-3167-f011-81dc-00505682eca9"), 3, 5, null, null, null, null, null },
                    { new Guid("402140f7-3167-f011-81dc-00505682eca9"), 4, 5, null, null, null, null, null },
                    { new Guid("412140f7-3167-f011-81dc-00505682eca9"), 5, 5, null, null, null, null, null },
                    { new Guid("422140f7-3167-f011-81dc-00505682eca9"), 6, 5, null, null, null, null, null },
                    { new Guid("432140f7-3167-f011-81dc-00505682eca9"), 7, 5, null, null, null, null, null },
                    { new Guid("442140f7-3167-f011-81dc-00505682eca9"), 8, 5, null, null, null, null, null },
                    { new Guid("452140f7-3167-f011-81dc-00505682eca9"), 9, 5, null, null, null, null, null },
                    { new Guid("462140f7-3167-f011-81dc-00505682eca9"), 1, 6, null, null, null, null, null },
                    { new Guid("472140f7-3167-f011-81dc-00505682eca9"), 2, 6, null, null, null, null, null },
                    { new Guid("482140f7-3167-f011-81dc-00505682eca9"), 3, 6, null, null, null, null, null },
                    { new Guid("492140f7-3167-f011-81dc-00505682eca9"), 4, 6, null, null, null, null, null },
                    { new Guid("4a2140f7-3167-f011-81dc-00505682eca9"), 5, 6, null, null, null, null, null },
                    { new Guid("4b2140f7-3167-f011-81dc-00505682eca9"), 6, 6, null, null, null, null, null },
                    { new Guid("4c2140f7-3167-f011-81dc-00505682eca9"), 7, 6, null, null, null, null, null },
                    { new Guid("4d2140f7-3167-f011-81dc-00505682eca9"), 8, 6, null, null, null, null, null },
                    { new Guid("4e2140f7-3167-f011-81dc-00505682eca9"), 9, 6, null, null, null, null, null },
                    { new Guid("4f2140f7-3167-f011-81dc-00505682eca9"), 1, 7, null, null, null, null, null },
                    { new Guid("502140f7-3167-f011-81dc-00505682eca9"), 2, 7, null, null, null, null, null },
                    { new Guid("512140f7-3167-f011-81dc-00505682eca9"), 3, 7, null, null, null, null, null },
                    { new Guid("522140f7-3167-f011-81dc-00505682eca9"), 4, 7, null, null, null, null, null },
                    { new Guid("532140f7-3167-f011-81dc-00505682eca9"), 5, 7, null, null, null, null, null },
                    { new Guid("542140f7-3167-f011-81dc-00505682eca9"), 6, 7, null, null, null, null, null },
                    { new Guid("552140f7-3167-f011-81dc-00505682eca9"), 7, 7, null, null, null, null, null },
                    { new Guid("562140f7-3167-f011-81dc-00505682eca9"), 8, 7, null, null, null, null, null },
                    { new Guid("572140f7-3167-f011-81dc-00505682eca9"), 9, 7, null, null, null, null, null },
                    { new Guid("582140f7-3167-f011-81dc-00505682eca9"), 1, 8, null, null, null, null, null },
                    { new Guid("592140f7-3167-f011-81dc-00505682eca9"), 2, 8, null, null, null, null, null },
                    { new Guid("5a2140f7-3167-f011-81dc-00505682eca9"), 3, 8, null, null, null, null, null },
                    { new Guid("5b2140f7-3167-f011-81dc-00505682eca9"), 4, 8, null, null, null, null, null },
                    { new Guid("5c2140f7-3167-f011-81dc-00505682eca9"), 5, 8, null, null, null, null, null },
                    { new Guid("5d2140f7-3167-f011-81dc-00505682eca9"), 6, 8, null, null, null, null, null },
                    { new Guid("5e2140f7-3167-f011-81dc-00505682eca9"), 7, 8, null, null, null, null, null },
                    { new Guid("5f2140f7-3167-f011-81dc-00505682eca9"), 8, 8, null, null, null, null, null },
                    { new Guid("602140f7-3167-f011-81dc-00505682eca9"), 9, 8, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyClaims_ClaimValueId",
                schema: "auth",
                table: "ApiKeyClaims",
                column: "ClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_ApiKeyHash",
                schema: "auth",
                table: "ApiKeys",
                column: "ApiKeyHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_AppId_Consumer",
                schema: "auth",
                table: "ApiKeys",
                columns: new[] { "AppId", "Consumer" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AppIndex",
                schema: "conf",
                table: "Apps",
                column: "AppIndex",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ApplicationName",
                schema: "conf",
                table: "Apps",
                column: "ApplicationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_DomainName",
                schema: "conf",
                table: "Apps",
                column: "DomainName",
                unique: true,
                filter: "[DomainName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_Prefix",
                schema: "conf",
                table: "Apps",
                column: "Prefix",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSafety_SignautreKey",
                schema: "conf",
                table: "AppSafety",
                column: "SignautreKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimValues_ClaimActionId_ClaimSectionId",
                schema: "sec",
                table: "ClaimValues",
                columns: new[] { "ClaimActionId", "ClaimSectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimValues_ClaimSectionId",
                schema: "sec",
                table: "ClaimValues",
                column: "ClaimSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_Email",
                schema: "id",
                table: "ContactInfo",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_PhoneNumber",
                schema: "id",
                table: "ContactInfo",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DomainCredentials_LoginTypeId",
                schema: "auth",
                table: "DomainCredentials",
                column: "LoginTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainCredentials_UserId",
                schema: "auth",
                table: "DomainCredentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainCredentials_UserName_LoginTypeId",
                schema: "auth",
                table: "DomainCredentials",
                columns: new[] { "UserName", "LoginTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HigherOrderEndpointOrigins_KeyId",
                schema: "sec",
                table: "HigherOrderEndpointOrigins",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_HigherOrderEndpoints_Method_Route",
                schema: "sec",
                table: "HigherOrderEndpoints",
                columns: new[] { "Method", "Route" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginApps_LoginTypeId",
                schema: "conf",
                table: "LoginApps",
                column: "LoginTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ClaimValueId",
                schema: "auth",
                table: "RoleClaims",
                column: "ClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoute_RouteId",
                schema: "auth",
                table: "RoleRoute",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AppId",
                schema: "id",
                table: "Roles",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Name_Path_Component",
                schema: "conf",
                table: "Routes",
                columns: new[] { "Name", "Path", "Component" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SingleCredentials_AppId_UserName",
                schema: "auth",
                table: "SingleCredentials",
                columns: new[] { "AppId", "UserName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_AppId",
                schema: "auth",
                table: "UserClaims",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ClaimValueId",
                schema: "auth",
                table: "UserClaims",
                column: "ClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "sec",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DocumentTypeId_DocumentNumber",
                schema: "id",
                table: "Users",
                columns: new[] { "DocumentTypeId", "DocumentNumber" },
                unique: true,
                filter: "[DocumentTypeId] IS NOT NULL AND [DocumentNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeyClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AppSafety",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "AppSettings",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "ContactInfo",
                schema: "id");

            migrationBuilder.DropTable(
                name: "DomainCredentials",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "HigherOrderEndpointOrigins",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "LoginApps",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "RoleRoute",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "SingleCredentials",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "ApiKeys",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "HigherOrderEndpoints",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "HigherOrderOrigins",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "LoginTypes",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "ClaimValues",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "id");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "id");

            migrationBuilder.DropTable(
                name: "ClaimActions",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "ClaimSections",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Apps",
                schema: "conf");
        }
    }
}
