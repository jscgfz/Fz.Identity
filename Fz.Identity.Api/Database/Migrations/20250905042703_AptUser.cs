using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AptUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.InsertData(
        //        schema: "auth",
        //        table: "Users",
        //        columns: new[] { "Id", "AreaId", "DeletedAtUtc", "DeletedBy", "IdentificationNumber", "ModifiedAtUtc", "ModifiedBy", "Name", "PhotoNodeId", "PrincipalEmail", "PrincipalEmailConfirmed", "PrincipalPhoneNumber", "PrincipalPhoneNumberConfirmed", "Surname", "Username" },
        //        values: new object[] { new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), "Atenea", null, "atenea.promotec@finanzatuo.com.co", false, null, false, "Promotec", "atenea.promotec" });

        //    migrationBuilder.InsertData(
        //        schema: "auth",
        //        table: "Credentials",
        //        columns: new[] { "Id", "CredentialEndUtc", "CredentialTypeId", "CredentialValue", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy", "PasswordHash", "PasswordSalt", "UserId" },
        //        values: new object[] { 1052, null, 4, "atenea.promotec", null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), new byte[] { 7, 225, 5, 182, 120, 18, 206, 254, 227, 159, 113, 133, 130, 191, 226, 35, 161, 253, 23, 137, 253, 113, 201, 254, 5, 184, 125, 230, 135, 108, 64, 218 }, new byte[] { 110, 143, 245, 135, 74, 61, 120, 117, 202, 78, 101, 168, 20, 121, 188, 78, 220, 98, 136, 107, 116, 82, 147, 251, 225, 32, 248, 228, 125, 35, 136, 185 }, new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2") });

        //    migrationBuilder.InsertData(
        //        schema: "conf",
        //        table: "UserApplications",
        //        columns: new[] { "ApplicationId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
        //        values: new object[] { 4, new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") });

        //    migrationBuilder.InsertData(
        //        schema: "auth",
        //        table: "UserRoles",
        //        columns: new[] { "RoleId", "UserId", "DeletedAtUtc", "DeletedBy", "ModifiedAtUtc", "ModifiedBy" },
        //        values: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2"), null, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Credentials",
            //    keyColumn: "Id",
            //    keyValue: 1052);

            //migrationBuilder.DeleteData(
            //    schema: "conf",
            //    table: "UserApplications",
            //    keyColumns: new[] { "ApplicationId", "UserId" },
            //    keyValues: new object[] { 4, new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2") });

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { new Guid("8149c0b3-18db-4c79-8df3-81300b7c5cfb"), new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2") });

            //migrationBuilder.DeleteData(
            //    schema: "auth",
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c08a4028-3bf6-4b94-8f97-89982f217eb2"));
        }
    }
}
