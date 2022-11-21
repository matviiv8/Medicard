using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class AddDoctorImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorImage_Doctor_DoctorId",
                table: "DoctorImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorImage",
                table: "DoctorImage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fda8a38-01b3-4b02-ae9b-0441a15f39ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab38b611-ac76-4e25-a375-416d558ba18d", "7d3d1031-b176-4513-a452-f090318d9417" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a82c5a80-c368-4add-924f-2de53939fa57", "8b15fda5-e02c-4b0a-b8e0-561725f44999" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6798a639-8a9d-49ae-80a3-572b9f4a313b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a82c5a80-c368-4add-924f-2de53939fa57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab38b611-ac76-4e25-a375-416d558ba18d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d3d1031-b176-4513-a452-f090318d9417");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b15fda5-e02c-4b0a-b8e0-561725f44999");

            migrationBuilder.RenameTable(
                name: "DoctorImage",
                newName: "Doctor image");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorImage_DoctorId",
                table: "Doctor image",
                newName: "IX_Doctor image_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor image",
                table: "Doctor image",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "011747c0-59c7-4c88-b971-a111593daaba", "b4be9f32-4abc-4db5-ac4e-12a1f4bf87e7", "Doctor", "DOCTOR" },
                    { "be4349e9-9493-44f4-8f24-ca680d9f44ea", "be1e817a-6197-4aee-8a4e-42b54fbab379", "Patient", "PATIENT" },
                    { "f2441f4d-4206-4a6c-89df-1f9e20eb8cda", "ef10ef28-5d07-4269-8c4d-1ca58c4257b3", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "12a69ba3-0519-4f10-8d9e-9fedc1ff11d3", 0, "bdb79983-efc8-4e9d-b496-3e7188302bd2", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEMNC+gf4TWSbW+jMe8nWY2JkEDTxmdsu4fOHMJjg8L4sIJJ8o8XxfMASaK55Su8olA==", null, false, "b94e3c58-f8db-459c-a4cc-285785d5759d", false, "mariakoval@gmail.com" },
                    { "46a12b23-5afd-47d2-945e-8f4e5d730981", 0, "1e698baf-ca02-48a4-b5ab-76d1ced862e7", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEN7KF97d2dOf1iSTDP8kcU8Z6vfEYonp872PeVqzNZ8odr77MG+HbCVd+AlIfgojFA==", null, false, "926b06b4-6c63-4f25-ac7d-fbcb0a0a5a42", false, "petrogrinkiv@gmail.com" },
                    { "af8c948f-020a-4678-9732-21e5a9973ff6", 0, "18cca749-bd1c-42d6-b1da-f561758dc225", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEGsnBZzi7P5unAz89tyvcKqnIQEgLL6GPluDofcFeLvpOIv1WiZbhCyJPqIY5OezUw==", null, false, "000b9f9b-fc52-4994-8932-f6ae7017e07a", false, "matviivandrij13@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "011747c0-59c7-4c88-b971-a111593daaba", "46a12b23-5afd-47d2-945e-8f4e5d730981" },
                    { "f2441f4d-4206-4a6c-89df-1f9e20eb8cda", "af8c948f-020a-4678-9732-21e5a9973ff6" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "46a12b23-5afd-47d2-945e-8f4e5d730981");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "12a69ba3-0519-4f10-8d9e-9fedc1ff11d3");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor image_Doctor_DoctorId",
                table: "Doctor image",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor image_Doctor_DoctorId",
                table: "Doctor image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor image",
                table: "Doctor image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4349e9-9493-44f4-8f24-ca680d9f44ea");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "011747c0-59c7-4c88-b971-a111593daaba", "46a12b23-5afd-47d2-945e-8f4e5d730981" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2441f4d-4206-4a6c-89df-1f9e20eb8cda", "af8c948f-020a-4678-9732-21e5a9973ff6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12a69ba3-0519-4f10-8d9e-9fedc1ff11d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "011747c0-59c7-4c88-b971-a111593daaba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2441f4d-4206-4a6c-89df-1f9e20eb8cda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46a12b23-5afd-47d2-945e-8f4e5d730981");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af8c948f-020a-4678-9732-21e5a9973ff6");

            migrationBuilder.RenameTable(
                name: "Doctor image",
                newName: "DoctorImage");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor image_DoctorId",
                table: "DoctorImage",
                newName: "IX_DoctorImage_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorImage",
                table: "DoctorImage",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9fda8a38-01b3-4b02-ae9b-0441a15f39ba", "4ae0bd14-cfae-42d4-b011-1c42d90f5d39", "Patient", "PATIENT" },
                    { "a82c5a80-c368-4add-924f-2de53939fa57", "232b6b47-0123-456b-a6e1-e8a045c2867d", "Doctor", "DOCTOR" },
                    { "ab38b611-ac76-4e25-a375-416d558ba18d", "b46f9ad9-9495-41c9-814b-425b8b2d51ba", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6798a639-8a9d-49ae-80a3-572b9f4a313b", 0, "8906b9a7-0a0e-4918-bf3d-ba8c0287a9b6", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEMRjrSG3wiAra1xj92v9F6Pw/3HNhsqmtR0U7UFXlPdn7q74TaFXLCBK+TnoenTFvA==", null, false, "e9ed06f1-a127-41c7-8e3c-61ec97c3def6", false, "mariakoval@gmail.com" },
                    { "7d3d1031-b176-4513-a452-f090318d9417", 0, "918bcb2a-9120-4b80-9f24-830a67d4f166", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEIU+WDI7spGc8uGw+0P+p9TlDqnSj5bEvFqUbUZ7jQrcPb17dSiPzydUXTe6PxUhvw==", null, false, "fedfbab5-50c9-46ab-a5a0-d2fe043d860d", false, "matviivandrij13@gmail.com" },
                    { "8b15fda5-e02c-4b0a-b8e0-561725f44999", 0, "b2d097e7-f2f7-430d-a170-1d5d2ca3a3f6", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEIsKMlqcxFi41T9ZDJXAM8w1heLoZ7CPlG+WtYbWCB9dfbrKI8/imNqCTqN8DneXpA==", null, false, "cbfae498-28cd-4276-a1cf-c20e4434cebf", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ab38b611-ac76-4e25-a375-416d558ba18d", "7d3d1031-b176-4513-a452-f090318d9417" },
                    { "a82c5a80-c368-4add-924f-2de53939fa57", "8b15fda5-e02c-4b0a-b8e0-561725f44999" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "8b15fda5-e02c-4b0a-b8e0-561725f44999");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "6798a639-8a9d-49ae-80a3-572b9f4a313b");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorImage_Doctor_DoctorId",
                table: "DoctorImage",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
