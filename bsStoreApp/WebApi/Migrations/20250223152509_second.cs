using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4308a98c-e57b-4fe6-ba74-ac5169e91a16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4882df-e140-4013-ba18-dba848b4fe2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ed6b5b-8ce6-4bb5-bb45-302f485bd8ed");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatagoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatagoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4739b4d0-9030-4283-be41-cdea57ebe819", null, "Editör", "EDITOR" },
                    { "491cec0f-5581-4b4f-a0b3-ccfa828c0ad8", null, "Admin", "ADMIN" },
                    { "58f66e93-ed65-4148-875b-62652d506358", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CatagoryId", "CatagoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network " },
                    { 3, "Database Management Systems " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4739b4d0-9030-4283-be41-cdea57ebe819");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491cec0f-5581-4b4f-a0b3-ccfa828c0ad8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58f66e93-ed65-4148-875b-62652d506358");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4308a98c-e57b-4fe6-ba74-ac5169e91a16", null, "Admin", "ADMIN" },
                    { "ab4882df-e140-4013-ba18-dba848b4fe2b", null, "User", "USER" },
                    { "e6ed6b5b-8ce6-4bb5-bb45-302f485bd8ed", null, "Editör", "EDITOR" }
                });
        }
    }
}
