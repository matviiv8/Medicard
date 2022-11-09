using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class UpdateColumnPatientAndDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9947f081-1b4a-4806-8b8e-9edeaa71a004");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "232ce553-adff-496d-a8ef-be86252f7f1e", "230bc3d2-0bbd-4cf4-96d5-73bd8ed43b73" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01d96aad-75bd-45cf-bb5f-790835ca56d5", "ba64fe5d-8fc1-4a1f-8c4d-756fb1ff414e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c081a3a-da48-44b6-aa27-fe6470dc3ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01d96aad-75bd-45cf-bb5f-790835ca56d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "232ce553-adff-496d-a8ef-be86252f7f1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230bc3d2-0bbd-4cf4-96d5-73bd8ed43b73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba64fe5d-8fc1-4a1f-8c4d-756fb1ff414e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09784b0a-16df-485c-a4b3-1fc120e4b789", "00ac6ff6-2270-4301-84cf-b5401503d5ee", "Patient", "PATIENT" },
                    { "62c3c15e-572f-4b2e-9ac1-7e031d2192ca", "4ce2b51a-9a2c-4144-a073-7fced87d2786", "Admin", "ADMIN" },
                    { "83ec2ea5-c9d1-4c1e-ab28-81b576890a53", "679a175c-e8f9-4fa0-9da8-05a3830cb898", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "195eef76-1fab-4682-8b26-cd9cb9788afb", 0, "7547ed8b-ead9-4338-b7bf-94abdc60c86a", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, null, null, "AQAAAAEAACcQAAAAEL3JHCXvhl6B78M8jjk4m2ghISExmM43zGkMzRawmwNiBjOADmfz1+luJuPuTJXwOg==", null, false, "5fbb6f4f-2718-4b5d-a233-89fd9dd9fc1d", false, "matviivandrij13@gmail.com" },
                    { "ba67617e-296e-42ae-86f1-683dc73b2230", 0, "6ac92610-5e04-48ac-a737-8e28e9078411", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, null, null, "AQAAAAEAACcQAAAAENX+nVwmaDkEo1/2H5JwLe6aVLRCCFavfqtO/kvPzNJzp2nyiYxgqH6j6vKoA8wx2g==", null, false, "f4306c48-48b8-47f2-b724-e4af05b18ea7", false, "mariakoval@gmail.com" },
                    { "f075bf72-5502-4365-b171-e5015e6840db", 0, "c24a9169-bd4a-4033-a500-4b21610646fd", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, null, null, "AQAAAAEAACcQAAAAEEcMwQ1V3m0xSsA9sWAHLsq/1NXAGN22oIjmGHa1cmMCbZdO+rDdRGHkLNFZR9agkQ==", null, false, "3a72b57e-dab3-4ab1-ad79-974e86e8ed85", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "62c3c15e-572f-4b2e-9ac1-7e031d2192ca", "195eef76-1fab-4682-8b26-cd9cb9788afb" },
                    { "83ec2ea5-c9d1-4c1e-ab28-81b576890a53", "f075bf72-5502-4365-b171-e5015e6840db" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "f075bf72-5502-4365-b171-e5015e6840db");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "ba67617e-296e-42ae-86f1-683dc73b2230");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09784b0a-16df-485c-a4b3-1fc120e4b789");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62c3c15e-572f-4b2e-9ac1-7e031d2192ca", "195eef76-1fab-4682-8b26-cd9cb9788afb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83ec2ea5-c9d1-4c1e-ab28-81b576890a53", "f075bf72-5502-4365-b171-e5015e6840db" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba67617e-296e-42ae-86f1-683dc73b2230");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62c3c15e-572f-4b2e-9ac1-7e031d2192ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83ec2ea5-c9d1-4c1e-ab28-81b576890a53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "195eef76-1fab-4682-8b26-cd9cb9788afb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f075bf72-5502-4365-b171-e5015e6840db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01d96aad-75bd-45cf-bb5f-790835ca56d5", "0981f97e-2a03-4b71-9863-0c676ac84e31", "Doctor", "DOCTOR" },
                    { "232ce553-adff-496d-a8ef-be86252f7f1e", "2f599972-67a5-4533-84ed-da17a52c4c49", "Admin", "ADMIN" },
                    { "9947f081-1b4a-4806-8b8e-9edeaa71a004", "09fd9102-635d-481e-bd09-6758cd91935c", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "230bc3d2-0bbd-4cf4-96d5-73bd8ed43b73", 0, "388ed2e2-c7f8-4252-a9f2-30f43ff84b2d", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, null, null, "AQAAAAEAACcQAAAAEC3xklSIE58BbGZTpKxOuFVRnaCrD6D+ZKbqcbRk4QqSyN9o+idQqLh26oxTwMg2iw==", null, false, "b37835c2-6424-4ece-9b10-c28636704cfe", false, "matviivandrij13@gmail.com" },
                    { "2c081a3a-da48-44b6-aa27-fe6470dc3ec0", 0, "9df885f6-3b77-4135-8152-1b499c82acb5", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, null, null, "AQAAAAEAACcQAAAAEOfMWR6OQs5k7fqyZlUvfB4esYJfWobU698HI4e7VWglZGx46hXUSwBANVWOOZOSIg==", null, false, "07dac3b7-c64b-4c71-b6e9-ab63bdb0e104", false, "mariakoval@gmail.com" },
                    { "ba64fe5d-8fc1-4a1f-8c4d-756fb1ff414e", 0, "e776b469-d267-4829-86d8-c942cced4a44", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, null, null, "AQAAAAEAACcQAAAAEG5DeSGm6ExO2vGKoPK+BmuRrwiwIKh5pULB7VnnX5xEpJZu/gqGzsk76E0zkBoHjQ==", null, false, "71f61d19-474e-45d2-bc7a-65b9388b384c", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "232ce553-adff-496d-a8ef-be86252f7f1e", "230bc3d2-0bbd-4cf4-96d5-73bd8ed43b73" },
                    { "01d96aad-75bd-45cf-bb5f-790835ca56d5", "ba64fe5d-8fc1-4a1f-8c4d-756fb1ff414e" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "ba64fe5d-8fc1-4a1f-8c4d-756fb1ff414e");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "2c081a3a-da48-44b6-aa27-fe6470dc3ec0");
        }
    }
}
