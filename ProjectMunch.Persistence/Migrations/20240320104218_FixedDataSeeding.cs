using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectMunch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1f45ef73-4344-4ce7-8619-b3a4ba013b32", "e968d8d2-89da-4478-9e8f-cbbf5d300e7a", "Admin", "ADMIN" },
                    { "31970cf7-e77c-416a-ac9d-f73ef2894111", "201323df-ce26-4ff3-bdb3-fafce7d9ec2a", "Verified", "VERIFIED" },
                    { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "dad59009-97ed-4f4d-8dfc-e708a4761714", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0712aaac-a550-461c-9051-6401ec876151", 0, "a14857a7-4417-41df-b73a-7c6c83ed4c52", "verified@example.com", false, false, null, "VERIFIED@EXAMPLE.COM", "VERIFIED", "AQAAAAIAAYagAAAAEPuVJnf+XvzsZWUpYCrozZ6/uzRZU9Lxip/BJPq1qryhh19ThMywpL3bkdBVCDmVkA==", null, false, "e59b4cdd-f78f-4780-885d-48e402a47080", false, "verified" },
                    { "156068d4-f2c2-48f6-808d-219e2de742d5", 0, "872d4735-bb62-4d7b-925d-1bbd7ded8f81", "user@example.com", false, false, null, "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEAv1Yybfyt8PFI29O/brNDV+q2CqkEN89Hgq2jLRHgB5hPpOSNKn5PvEtj2vGHU94g==", null, false, "ef1469c9-4bc8-47d6-9520-d6d386d5d041", false, "user" },
                    { "c16a609f-7b0c-4d65-a002-d8c00a558c53", 0, "9bc43052-e931-4a7e-aaa5-9ef0125ec8e0", "admin@example.com", false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEMD16hI0kmUkdISF36b23FznrX+BsVpz3OXCLbzh7YsQfp7+ZH6o0Ul4c6pITpMHtQ==", null, false, "e8c1dec2-5b8a-4eca-b214-8effaea2bd97", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "31970cf7-e77c-416a-ac9d-f73ef2894111", "0712aaac-a550-461c-9051-6401ec876151" },
                    { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "0712aaac-a550-461c-9051-6401ec876151" },
                    { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "156068d4-f2c2-48f6-808d-219e2de742d5" },
                    { "1f45ef73-4344-4ce7-8619-b3a4ba013b32", "c16a609f-7b0c-4d65-a002-d8c00a558c53" },
                    { "31970cf7-e77c-416a-ac9d-f73ef2894111", "c16a609f-7b0c-4d65-a002-d8c00a558c53" },
                    { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "c16a609f-7b0c-4d65-a002-d8c00a558c53" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "31970cf7-e77c-416a-ac9d-f73ef2894111", "0712aaac-a550-461c-9051-6401ec876151" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "0712aaac-a550-461c-9051-6401ec876151" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "156068d4-f2c2-48f6-808d-219e2de742d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f45ef73-4344-4ce7-8619-b3a4ba013b32", "c16a609f-7b0c-4d65-a002-d8c00a558c53" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "31970cf7-e77c-416a-ac9d-f73ef2894111", "c16a609f-7b0c-4d65-a002-d8c00a558c53" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf51d8b9-5465-4149-8184-8b3dacd05c12", "c16a609f-7b0c-4d65-a002-d8c00a558c53" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f45ef73-4344-4ce7-8619-b3a4ba013b32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31970cf7-e77c-416a-ac9d-f73ef2894111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf51d8b9-5465-4149-8184-8b3dacd05c12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0712aaac-a550-461c-9051-6401ec876151");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156068d4-f2c2-48f6-808d-219e2de742d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c16a609f-7b0c-4d65-a002-d8c00a558c53");

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
    }
}
