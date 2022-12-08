using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class EditMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e585c5f-662f-4968-8bf2-3827037e794f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4500a2d7-075b-4f9d-bf26-5f90abdd5260", "cb436c87-99f9-4f4c-aea4-637710b713de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "47e8b9d5-df59-45ac-a7d1-45ccd2c7cf54", "e34e761a-a813-47b1-8538-5a8385986564" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "311cb0ab-f2af-4251-a47a-bea1eed5ab11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4500a2d7-075b-4f9d-bf26-5f90abdd5260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47e8b9d5-df59-45ac-a7d1-45ccd2c7cf54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb436c87-99f9-4f4c-aea4-637710b713de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e34e761a-a813-47b1-8538-5a8385986564");

            migrationBuilder.AddColumn<string>(
                name: "TargetId",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TargetName",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d6f843a-69ea-471a-9c7d-0f34d966c7ca", "54005303-853c-43a5-84e7-1bd42e74ee0c", "Admin", "ADMIN" },
                    { "ed1e9388-1aac-4734-a97e-e92052d20b80", "b4ea3eec-8648-474c-9f59-4cdbcaae1292", "Doctor", "DOCTOR" },
                    { "f773c497-9b09-42d9-a8fb-6a63e7d36b51", "0ee0dd24-b91e-45af-b2ce-a09012c5a30f", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05b9ea37-79e2-437d-9a68-28c4da123630", 0, "36bd4619-0d78-4145-8cd6-bdb688a4c4f2", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEIzzjcA5tg42XtKAIK/+/1jDygzs9pRz21fT8rDb4UWSnQOJRuRLtJU7KDcfZRogbQ==", null, false, "2b4ff0c7-3b96-4272-8f1e-d8d712170bee", false, "matviivandrij13@gmail.com" },
                    { "7a99585d-5d68-4e9f-a49f-4de3395d8c67", 0, "d792db4c-3fd5-49cb-9ede-3fbc4691df3f", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAECD/PahSNZHx61IEoKldWTxJAvABuYyMZxf2QQ5jvboQe/o9fCI9SDoXFr9OSo3aIg==", null, false, "958ece8e-df81-4a09-a30e-f0e0ea898431", false, "petrogrinkiv@gmail.com" },
                    { "e829138a-e0dd-4b2d-9e93-b3b64e22d74b", 0, "a40b0806-6f78-4d67-896b-25838174b7c7", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEFqq9Vroce76fhL3ax3lo4PUWUoMVL9HvEBIbsZVPpS0FVjj9GN5t0PrZZm9i5F5EQ==", null, false, "5c1e8779-3347-41fb-acbb-6c61b699e32f", false, "mariakoval@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8d6f843a-69ea-471a-9c7d-0f34d966c7ca", "05b9ea37-79e2-437d-9a68-28c4da123630" },
                    { "ed1e9388-1aac-4734-a97e-e92052d20b80", "7a99585d-5d68-4e9f-a49f-4de3395d8c67" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "7a99585d-5d68-4e9f-a49f-4de3395d8c67");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "e829138a-e0dd-4b2d-9e93-b3b64e22d74b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f773c497-9b09-42d9-a8fb-6a63e7d36b51");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6f843a-69ea-471a-9c7d-0f34d966c7ca", "05b9ea37-79e2-437d-9a68-28c4da123630" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed1e9388-1aac-4734-a97e-e92052d20b80", "7a99585d-5d68-4e9f-a49f-4de3395d8c67" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e829138a-e0dd-4b2d-9e93-b3b64e22d74b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6f843a-69ea-471a-9c7d-0f34d966c7ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1e9388-1aac-4734-a97e-e92052d20b80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05b9ea37-79e2-437d-9a68-28c4da123630");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a99585d-5d68-4e9f-a49f-4de3395d8c67");

            migrationBuilder.DropColumn(
                name: "TargetId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "TargetName",
                table: "Message");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e585c5f-662f-4968-8bf2-3827037e794f", "a6eb2b0c-c418-4ef2-9caa-a3089fbc8047", "Patient", "PATIENT" },
                    { "4500a2d7-075b-4f9d-bf26-5f90abdd5260", "44683a45-5741-4047-9e1a-41ca88abfd43", "Doctor", "DOCTOR" },
                    { "47e8b9d5-df59-45ac-a7d1-45ccd2c7cf54", "a462e2e4-358c-4130-8e45-ed6855e1dfac", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "311cb0ab-f2af-4251-a47a-bea1eed5ab11", 0, "dc23fd71-bbc1-4223-80b8-b6bbc260605e", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEDIBCWp0xFcSFUT3YhbZzL2W6FuMKxYZDCIb78qgD+2IGhqusdPGXVjo4AyUU7Ncvw==", null, false, "75d0221f-6f45-47d9-8c36-4e4c88abf7d5", false, "mariakoval@gmail.com" },
                    { "cb436c87-99f9-4f4c-aea4-637710b713de", 0, "5b75bc62-7564-4ac5-970a-4ed791f6cb36", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEA8SVMdKSIcQvMtyPunoSGKqLJcNW0n7R1eIJS7x+pa7UYK60SyMxHO076GAF27xQA==", null, false, "df9328be-500d-41e4-a85c-1e0c6ca1ba00", false, "petrogrinkiv@gmail.com" },
                    { "e34e761a-a813-47b1-8538-5a8385986564", 0, "fe947b02-73fe-4b59-a065-ad2c1b0f29f3", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEJMMLf0DpcsjHRAYsF8lo/A3ow3xUG8h+acVMA/erqckYNsk/XJ2cfWj6O7wTc2l9A==", null, false, "aeb16ecd-e372-455e-b168-b38c1b36e045", false, "matviivandrij13@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4500a2d7-075b-4f9d-bf26-5f90abdd5260", "cb436c87-99f9-4f4c-aea4-637710b713de" },
                    { "47e8b9d5-df59-45ac-a7d1-45ccd2c7cf54", "e34e761a-a813-47b1-8538-5a8385986564" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "cb436c87-99f9-4f4c-aea4-637710b713de");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "311cb0ab-f2af-4251-a47a-bea1eed5ab11");
        }
    }
}
