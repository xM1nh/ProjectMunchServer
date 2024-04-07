using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectMunch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e0ce2a-e05b-4cb6-b00e-18ccd3de3de2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f5ce1f1-1b57-44ce-8253-a7e3d41071e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4dd64f26-dfb7-4a1f-aed2-54bb8436909c", "37a3fbf4-f83d-42ff-aea1-2c221a6cdfd8", "Admin", "ADMIN" },
                    { "66d1d245-a24d-4e8f-b56c-bf1a939b53e8", "568fdfe3-325a-4954-b65c-3e388163da7f", "Verified", "VERIFIED" },
                    { "e898c72d-004c-48a5-b754-59361b80691a", "b49a675c-1ed0-4597-bff1-289614f6dd84", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a7bf293-f030-4f64-bed7-c4b8e57b728f", 0, "3070a88a-0ec9-4eb3-be3a-603bf744a1d2", "verified@example.com", false, false, null, "VERIFIED@EXAMPLE.COM", "VERIFIED", null, null, false, "07078d2c-cb94-4763-a680-ccb98edebd4b", false, "verified" },
                    { "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b", 0, "512414a6-a335-4ca7-bff8-c74c68a0c1ad", "admin@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", null, null, false, "a7948c9b-3ac2-4ba2-b348-b15fb60f97b0", false, "admin" },
                    { "f130be1f-500e-4124-8ea7-983613207158", 0, "9e3c868e-527b-415e-ae8c-e9021bb821a2", "user@example.com", false, false, null, "USER@EXAMPLE.COM", "USER", null, null, false, "bcc363f7-0196-4b11-9fc7-2c3e51b8420c", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "66d1d245-a24d-4e8f-b56c-bf1a939b53e8", "6a7bf293-f030-4f64-bed7-c4b8e57b728f" },
                    { "e898c72d-004c-48a5-b754-59361b80691a", "6a7bf293-f030-4f64-bed7-c4b8e57b728f" },
                    { "4dd64f26-dfb7-4a1f-aed2-54bb8436909c", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" },
                    { "66d1d245-a24d-4e8f-b56c-bf1a939b53e8", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" },
                    { "e898c72d-004c-48a5-b754-59361b80691a", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" },
                    { "e898c72d-004c-48a5-b754-59361b80691a", "f130be1f-500e-4124-8ea7-983613207158" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66d1d245-a24d-4e8f-b56c-bf1a939b53e8", "6a7bf293-f030-4f64-bed7-c4b8e57b728f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e898c72d-004c-48a5-b754-59361b80691a", "6a7bf293-f030-4f64-bed7-c4b8e57b728f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4dd64f26-dfb7-4a1f-aed2-54bb8436909c", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66d1d245-a24d-4e8f-b56c-bf1a939b53e8", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e898c72d-004c-48a5-b754-59361b80691a", "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e898c72d-004c-48a5-b754-59361b80691a", "f130be1f-500e-4124-8ea7-983613207158" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd64f26-dfb7-4a1f-aed2-54bb8436909c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d1d245-a24d-4e8f-b56c-bf1a939b53e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e898c72d-004c-48a5-b754-59361b80691a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a7bf293-f030-4f64-bed7-c4b8e57b728f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd6c6397-ab6c-439b-bf6a-7b5b9a58e21b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f130be1f-500e-4124-8ea7-983613207158");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35e0ce2a-e05b-4cb6-b00e-18ccd3de3de2", "352f1629-575e-43cc-a299-8efbf92c06d1", "VerifiedUser", "VERIFIEDUSER" },
                    { "3f5ce1f1-1b57-44ce-8253-a7e3d41071e0", "06dfe4bb-b3bc-4769-a0dc-20af352e8e78", "Admin", "ADMIN" }
                });
        }
    }
}
