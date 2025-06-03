using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fz.Identity.Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class CredentialsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "auth",
                table: "Credentials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "auth",
                table: "Credentials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "jhon.cubillos", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "JCubillos", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "christian.chilatra", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "jesus.perez", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "laura.roa", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "jose.bernal", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "darcy.novoa", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "elizabeth.gamba", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "carlos.molano", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "monica.infante", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "jeymmy.camelo", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "johanna.riano", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "jose.carrillo", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "nicolas.rico", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "astrid.meneses", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "arlein.pomar", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "julieth.quinones", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "laura.rueda", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "paula.moreno", null, null });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CredentialValue", "PasswordHash", "PasswordSalt" },
                values: new object[] { "oscar.vinasco", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "auth",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "auth",
                table: "Credentials");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CredentialValue",
                value: "{\"Username\":\"jhon.cubillos\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CredentialValue",
                value: "{\"Username\":\"JCubillos\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CredentialValue",
                value: "{\"Username\":\"christian.chilatra\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 4,
                column: "CredentialValue",
                value: "{\"Username\":\"jesus.perez\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 5,
                column: "CredentialValue",
                value: "{\"Username\":\"laura.roa\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 6,
                column: "CredentialValue",
                value: "{\"Username\":\"jose.bernal\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 7,
                column: "CredentialValue",
                value: "{\"Username\":\"darcy.novoa\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 8,
                column: "CredentialValue",
                value: "{\"Username\":\"elizabeth.gamba\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 9,
                column: "CredentialValue",
                value: "{\"Username\":\"carlos.molano\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 10,
                column: "CredentialValue",
                value: "{\"Username\":\"monica.infante\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 11,
                column: "CredentialValue",
                value: "{\"Username\":\"jeymmy.camelo\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 12,
                column: "CredentialValue",
                value: "{\"Username\":\"johanna.riano\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 13,
                column: "CredentialValue",
                value: "{\"Username\":\"jose.carrillo\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 14,
                column: "CredentialValue",
                value: "{\"Username\":\"nicolas.rico\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 15,
                column: "CredentialValue",
                value: "{\"Username\":\"astrid.meneses\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 16,
                column: "CredentialValue",
                value: "{\"Username\":\"arlein.pomar\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 17,
                column: "CredentialValue",
                value: "{\"Username\":\"julieth.quinones\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 18,
                column: "CredentialValue",
                value: "{\"Username\":\"laura.rueda\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 19,
                column: "CredentialValue",
                value: "{\"Username\":\"paula.moreno\"}");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Credentials",
                keyColumn: "Id",
                keyValue: 20,
                column: "CredentialValue",
                value: "{\"Username\":\"oscar.vinasco\"}");
        }
    }
}
