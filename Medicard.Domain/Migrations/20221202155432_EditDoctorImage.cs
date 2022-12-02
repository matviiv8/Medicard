using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medicard.Domain.Migrations
{
    public partial class EditDoctorImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8c3e7d3-f786-4d85-99b9-cf7a1a01df03", "08a75bd6-1c3a-4a00-bdce-2baea1acf7d5", "Patient", "PATIENT" },
                    { "ed3333ab-db37-4057-aaff-4b61f64be27e", "ceb36d2d-6406-4a3e-8d3e-74584d6a30c0", "Doctor", "DOCTOR" },
                    { "ede44275-816e-4de7-9aee-c39bd0dcb966", "3796b066-ee59-4470-b66f-3b8394e2d888", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5befd447-bcd3-4a3f-b300-131a818f9035", 0, "64e4d97d-b124-489a-931e-45da3eda0929", "mariakoval@gmail.com", false, "Maria", "Koval", false, null, "MARIAKOVAL@GMAIL.COM", "MARIAKOVAL@GMAIL.COM", "AQAAAAEAACcQAAAAEHIj9hqKJ8qwv49+exCVnb1dAITQjk/8HypVGiF79yTHQmL7O0HmMyDZuvS4Clfl6g==", null, false, "9e49e185-bcd4-4d19-a937-88c161ca07e0", false, "mariakoval@gmail.com" },
                    { "83f02277-dbad-4f40-bf29-9536f31a9bd5", 0, "4d75cfac-26bb-4cb7-a319-d3bd1adca83c", "matviivandrij13@gmail.com", false, "Andrij", "Matviiv", false, null, "MATVIIVANDRIJ13@GMAIL.COM", "MATVIIVANDRIJ13@GMAIL.COM", "AQAAAAEAACcQAAAAEIbsqJWGK6pC+Fgp33EgwIgVFvxVVi1DHzyxcH4qT9uA/3poMcX3vJpcNvXbNiqaNw==", null, false, "7d115234-8ee5-4262-9375-c48db9e31e9c", false, "matviivandrij13@gmail.com" },
                    { "a218e893-e886-4aa5-9357-2ae18be53e97", 0, "ea53d5f6-390e-4a62-a136-f73b5f439752", "petrogrinkiv@gmail.com", false, "Petro", "Grinkiv", false, null, "PETROGRINKOV@GMAIL.COM", "PETROGRINKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEEB62gJn7Gl0usNGm7x7C3JNB8h9u/l7L1/vSACFrIbLJpcHQAbBwFe8n+BXuWMyPA==", null, false, "db87cb42-5e31-4073-9e9d-33646caf8514", false, "petrogrinkiv@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ede44275-816e-4de7-9aee-c39bd0dcb966", "83f02277-dbad-4f40-bf29-9536f31a9bd5" },
                    { "ed3333ab-db37-4057-aaff-4b61f64be27e", "a218e893-e886-4aa5-9357-2ae18be53e97" }
                });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DoctorPicture", "UserId" },
                values: new object[] { "menunknowndoctor.jpeg", "a218e893-e886-4aa5-9357-2ae18be53e97" });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DoctorPicture", "UserId" },
                values: new object[] { "womenunknowndoctor.jpeg", "5befd447-bcd3-4a3f-b300-131a818f9035" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8c3e7d3-f786-4d85-99b9-cf7a1a01df03");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ede44275-816e-4de7-9aee-c39bd0dcb966", "83f02277-dbad-4f40-bf29-9536f31a9bd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed3333ab-db37-4057-aaff-4b61f64be27e", "a218e893-e886-4aa5-9357-2ae18be53e97" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5befd447-bcd3-4a3f-b300-131a818f9035");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed3333ab-db37-4057-aaff-4b61f64be27e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede44275-816e-4de7-9aee-c39bd0dcb966");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83f02277-dbad-4f40-bf29-9536f31a9bd5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a218e893-e886-4aa5-9357-2ae18be53e97");

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
                columns: new[] { "DoctorPicture", "UserId" },
                values: new object[] { null, "e3ee8d87-f2a0-449a-89a4-dc47f917297d" });

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DoctorPicture", "UserId" },
                values: new object[] { null, "0d6edbf7-5982-46dd-abac-be23f5c79efd" });
        }
    }
}
