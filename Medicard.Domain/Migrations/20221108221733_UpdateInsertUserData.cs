using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class UpdateInsertUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c367412-52fa-4081-97ee-500f14310811");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b238199-63c6-4474-97e0-c7b4c33aeeae", "0f1e073b-df56-41d8-9201-29d679e9dec0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9ebafbe-4f60-419d-b022-8e2be123985f", "44923958-4a4b-416d-81e6-b10ed4967396" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b238199-63c6-4474-97e0-c7b4c33aeeae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9ebafbe-4f60-419d-b022-8e2be123985f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f1e073b-df56-41d8-9201-29d679e9dec0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44923958-4a4b-416d-81e6-b10ed4967396");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "108e29c6-6560-4fe2-bb2b-f789a49ac7c9", "14d951d2-f4c1-459b-8cc0-e91088ab5045", "Patient", "PATIENT" },
                    { "ae7c75df-2d56-4fd2-b36b-8f3690122117", "efd328fb-314a-4c80-a2cc-caa5e9f1a64c", "Admin", "ADMIN" },
                    { "edbe2e76-10ec-43b1-9d06-72f923bbb8e9", "06715bb2-e295-4260-a738-c50206157b70", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "38dcc1d9-361a-4e81-b5c2-fe71bfa8a588", 0, "a47c2151-543f-4bb6-b7cf-37e25228a808", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, null, null, "AQAAAAEAACcQAAAAEIlAqMpFYvrq93SHLwT9v2zuNeJODK26ddtuTcf8rTASOUvpw9jJfmzPEmxoD+0ELg==", null, false, "812f2330-b519-490c-80ea-7e0851bfd075", false, "matviivandrij13@gmail.com" },
                    { "86549f70-be58-4fb4-b7b9-a0e8f2f78447", 0, "8bfab1cd-a815-4bef-b697-03dc80d67342", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, null, null, "AQAAAAEAACcQAAAAEInELjv7qWqSo8kgcxZx5KLZfdm7nWujxVj/OwryW3YgazCEqCLAbqMlilgSljW22g==", null, false, "f5672eea-8e5c-4b28-babd-4aa11d7c2014", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ae7c75df-2d56-4fd2-b36b-8f3690122117", "38dcc1d9-361a-4e81-b5c2-fe71bfa8a588" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "edbe2e76-10ec-43b1-9d06-72f923bbb8e9", "86549f70-be58-4fb4-b7b9-a0e8f2f78447" });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "86549f70-be58-4fb4-b7b9-a0e8f2f78447");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "108e29c6-6560-4fe2-bb2b-f789a49ac7c9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ae7c75df-2d56-4fd2-b36b-8f3690122117", "38dcc1d9-361a-4e81-b5c2-fe71bfa8a588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edbe2e76-10ec-43b1-9d06-72f923bbb8e9", "86549f70-be58-4fb4-b7b9-a0e8f2f78447" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae7c75df-2d56-4fd2-b36b-8f3690122117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbe2e76-10ec-43b1-9d06-72f923bbb8e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38dcc1d9-361a-4e81-b5c2-fe71bfa8a588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86549f70-be58-4fb4-b7b9-a0e8f2f78447");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b238199-63c6-4474-97e0-c7b4c33aeeae", "0f2608ce-3cf5-47a1-888e-a1a368fcc79f", "Doctor", "DOCTOR" },
                    { "9c367412-52fa-4081-97ee-500f14310811", "38311e14-4477-4da9-8f9b-a0c19455c2b1", "Patient", "PATIENT" },
                    { "c9ebafbe-4f60-419d-b022-8e2be123985f", "0eff758f-265f-4b69-8c3f-1d407434ce90", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f1e073b-df56-41d8-9201-29d679e9dec0", 0, "0747dc1e-6596-427b-ab91-ba580cca8f00", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, null, null, "AQAAAAEAACcQAAAAEFEuoBKOUB+ar/Deev7wiLA8BIFnrPz1F+mNfTnJkjgcKZlcG3u1ritBgtpEguFH4w==", null, false, "69e5e899-8648-468c-a354-bbee2bd16646", false, null },
                    { "44923958-4a4b-416d-81e6-b10ed4967396", 0, "586fcf56-3351-4a86-817c-c4e8b5712125", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, null, null, "AQAAAAEAACcQAAAAEHGP2J6nDxg3ghE8KS573hnZU1Zu36jMIlYdARMFKXd0SzHm4pv06V55vDeM1+uESA==", null, false, "3d93e31c-af97-4922-97ff-45a5ef98c575", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7b238199-63c6-4474-97e0-c7b4c33aeeae", "0f1e073b-df56-41d8-9201-29d679e9dec0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9ebafbe-4f60-419d-b022-8e2be123985f", "44923958-4a4b-416d-81e6-b10ed4967396" });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "0f1e073b-df56-41d8-9201-29d679e9dec0");
        }
    }
}
