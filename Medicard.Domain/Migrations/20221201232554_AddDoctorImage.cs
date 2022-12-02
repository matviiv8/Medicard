using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class AddDoctorImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac8b368-e487-40e9-85f7-cad758601500");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3295a7b4-1900-44c3-b424-ce5bd487d941", "c7b66d0d-971e-41cf-8fd6-f4b0da69d31f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "43fa2330-a02e-4cc4-8aa6-dcd9e899d51a", "e8c257ae-3023-4879-934a-6d905fe8de0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae8e3be6-aff9-4c26-9ac0-debf81aa7185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3295a7b4-1900-44c3-b424-ce5bd487d941");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43fa2330-a02e-4cc4-8aa6-dcd9e899d51a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7b66d0d-971e-41cf-8fd6-f4b0da69d31f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8c257ae-3023-4879-934a-6d905fe8de0a");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Doctor",
                newName: "ImageId");

            migrationBuilder.CreateTable(
                name: "Doctor image",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3295a7b4-1900-44c3-b424-ce5bd487d941", "1a510147-ddcf-4178-9e8c-eb61a15b9223", "Admin", "ADMIN" },
                    { "43fa2330-a02e-4cc4-8aa6-dcd9e899d51a", "73d72f5c-58ff-4bc1-9dad-bccd549f44fd", "Doctor", "DOCTOR" },
                    { "aac8b368-e487-40e9-85f7-cad758601500", "8ce77fc6-05a6-4e2f-a87d-1a7308b7ff6a", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ae8e3be6-aff9-4c26-9ac0-debf81aa7185", 0, "a4fb0b9f-76f7-42a0-98f8-4bb81264a0d8", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEN7RA+/jjhpoKeDvfWWfmFwb0wrqS0lIuabMYOWpTjnAxLvCw68uKnMRIPJu2VPOkg==", null, false, "e5f7eec6-cb61-4d5a-aa57-b209c77dc8ae", false, "mariakoval@gmail.com" },
                    { "c7b66d0d-971e-41cf-8fd6-f4b0da69d31f", 0, "93beb086-14bd-4310-8c9a-e4765893128f", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEH2JS1vPBkj7vgiucKIJeZojvJCqaHGucvBq50OIraL+2MX5gJSEx/kofqicB1T6GQ==", null, false, "3b7b4c4c-eb02-4a85-a026-3597adfbb05c", false, "matviivandrij13@gmail.com" },
                    { "e8c257ae-3023-4879-934a-6d905fe8de0a", 0, "6199490a-3eac-4188-abc2-9fe8b82b708a", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAECySvhhvlubhLdjhDCEBvBjOIGtfxfVgDtWYSyDq+gypj7jjQCI4zkEBvv9zbYUuRQ==", null, false, "262b6098-78c1-4f55-9d3b-b19a8c138bdf", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3295a7b4-1900-44c3-b424-ce5bd487d941", "c7b66d0d-971e-41cf-8fd6-f4b0da69d31f" },
                    { "43fa2330-a02e-4cc4-8aa6-dcd9e899d51a", "e8c257ae-3023-4879-934a-6d905fe8de0a" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "e8c257ae-3023-4879-934a-6d905fe8de0a");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "ae8e3be6-aff9-4c26-9ac0-debf81aa7185");
        }
    }
}
