using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c8c87fe-dd91-4d37-8749-bf323c9096e2", null, "User", "USER" },
                    { "1ce3f9dd-970a-46ef-a489-b387469dd7d9", null, "Admin", "ADMIN" },
                    { "7d16bd2f-6188-4770-a28f-e2dcb1139e19", null, "Editör", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c8c87fe-dd91-4d37-8749-bf323c9096e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ce3f9dd-970a-46ef-a489-b387469dd7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d16bd2f-6188-4770-a28f-e2dcb1139e19");
        }
    }
}
