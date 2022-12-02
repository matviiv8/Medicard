using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class EditDoctorPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4b7cde7-95c2-4d6a-b0b0-6d68c8bd53fb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38b7a5c4-8b98-4ec1-bfc4-d4cab3dd4e32", "7eae22bf-5791-4e22-8794-8d5a957b9675" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2fc3aea-04c5-4e13-955d-28446d7f6278", "bf696e49-4340-4035-8a33-a6058a8130a3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a998c15-68e7-4ab9-905a-cd020ab6983a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b7a5c4-8b98-4ec1-bfc4-d4cab3dd4e32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2fc3aea-04c5-4e13-955d-28446d7f6278");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7eae22bf-5791-4e22-8794-8d5a957b9675");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf696e49-4340-4035-8a33-a6058a8130a3");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Doctor",
                newName: "DoctorPicture");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c860915-de3b-40e3-b74f-73d37603de2f", "89e41ace-da2b-489b-9d3f-9041d9405ead", "Admin", "ADMIN" },
                    { "71ec70cf-094c-4ba0-a4e5-c212d252e03d", "873179b3-1671-4a1d-b693-ff558fca8e0a", "Doctor", "DOCTOR" },
                    { "ea00f06a-0ed3-487e-80bc-6457cd0185f0", "347c968f-59c8-4cc6-a474-672825cf2e11", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d6edbf7-5982-46dd-abac-be23f5c79efd", 0, "8182ea4a-8891-4e26-be1f-5a0c9e0d281f", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEKMzR0JjtplG5Eev04X1lusyES9JYc1Hn30daruaALeJg3Q4ylqyDXwKimGsmdn3Lw==", null, false, "e76c844f-1096-4b92-8fcb-3ada6ac777f8", false, "mariakoval@gmail.com" },
                    { "5b10a5c9-c9b1-46e9-9a95-99a4b02feb97", 0, "cfaa21c9-5cb1-4502-8b6b-cdc0a46c5460", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEChfAJ2JRfytF4sK4e5aJPceNKwlcpVfM16AYfM5HuQ3d1PirrFlisOGpnbYDjrm8g==", null, false, "53cbfda4-2cd8-4a92-92b3-75eee5684069", false, "matviivandrij13@gmail.com" },
                    { "e3ee8d87-f2a0-449a-89a4-dc47f917297d", 0, "2cbcf042-58da-4965-b975-7e715cb079d2", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEHfDYjVfDc7R0dxuhmfe4ICFrItkwJdrl29J1mldYvxdS+ecKPbUWGBhmIr5OPnRTA==", null, false, "78143911-19f2-4b69-95e7-915512f54381", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5c860915-de3b-40e3-b74f-73d37603de2f", "5b10a5c9-c9b1-46e9-9a95-99a4b02feb97" },
                    { "71ec70cf-094c-4ba0-a4e5-c212d252e03d", "e3ee8d87-f2a0-449a-89a4-dc47f917297d" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "e3ee8d87-f2a0-449a-89a4-dc47f917297d");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "0d6edbf7-5982-46dd-abac-be23f5c79efd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea00f06a-0ed3-487e-80bc-6457cd0185f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c860915-de3b-40e3-b74f-73d37603de2f", "5b10a5c9-c9b1-46e9-9a95-99a4b02feb97" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71ec70cf-094c-4ba0-a4e5-c212d252e03d", "e3ee8d87-f2a0-449a-89a4-dc47f917297d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d6edbf7-5982-46dd-abac-be23f5c79efd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c860915-de3b-40e3-b74f-73d37603de2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ec70cf-094c-4ba0-a4e5-c212d252e03d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b10a5c9-c9b1-46e9-9a95-99a4b02feb97");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3ee8d87-f2a0-449a-89a4-dc47f917297d");

            migrationBuilder.RenameColumn(
                name: "DoctorPicture",
                table: "Doctor",
                newName: "ImageId");

            migrationBuilder.CreateTable(
                name: "Doctor image",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor image_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38b7a5c4-8b98-4ec1-bfc4-d4cab3dd4e32", "88937796-6d65-452c-85c5-6ab85181dd02", "Admin", "ADMIN" },
                    { "e4b7cde7-95c2-4d6a-b0b0-6d68c8bd53fb", "648c1506-20f8-4db6-a611-10da2c6ef4f3", "Patient", "PATIENT" },
                    { "f2fc3aea-04c5-4e13-955d-28446d7f6278", "8d9c9503-f30b-47ab-8d3c-2625da1753b5", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7eae22bf-5791-4e22-8794-8d5a957b9675", 0, "6fdf416f-ff74-4cd3-8162-ece481e31e92", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAELksarZC2nTEO5d/Oxubel7B2Y6+DkKRpyKY0mc3pFmhP1R5tfXGxeWOLgJLIMPRiw==", null, false, "878d70c7-8b92-49bc-8617-f7fe6dc630f6", false, "matviivandrij13@gmail.com" },
                    { "9a998c15-68e7-4ab9-905a-cd020ab6983a", 0, "f7734089-c43a-4701-8781-84b0a7d9ea44", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEEOnmGElKwAQMM0Zm+GPPCOiBusmPjHoqSiJ3YrH5mnnsEJURjCey4IvOI9O4G1LfQ==", null, false, "5eae0c9d-c672-4791-9e4f-ecd318d7a8e6", false, "mariakoval@gmail.com" },
                    { "bf696e49-4340-4035-8a33-a6058a8130a3", 0, "5c44aeee-7a42-4843-848c-1120f4ff1b16", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAELx2aQTfFZXOgwIUWKB5boI2oUFgU6zRkApsWE+j8GOleP/ERW3NMHxjYaJlodwgzw==", null, false, "ed1b447f-6bbe-4896-9717-fb21a9f2d480", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "38b7a5c4-8b98-4ec1-bfc4-d4cab3dd4e32", "7eae22bf-5791-4e22-8794-8d5a957b9675" },
                    { "f2fc3aea-04c5-4e13-955d-28446d7f6278", "bf696e49-4340-4035-8a33-a6058a8130a3" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "bf696e49-4340-4035-8a33-a6058a8130a3");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "9a998c15-68e7-4ab9-905a-cd020ab6983a");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor image_DoctorId",
                table: "Doctor image",
                column: "DoctorId",
                unique: true);
        }
    }
}
