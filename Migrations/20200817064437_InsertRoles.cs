using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleAPI.Migrations
{
    public partial class InsertRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5227b3ff-a012-4d7d-9cc8-16066b6cf8bb", "5a318f01-1b5b-429c-aefb-889b47d6781b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd13b872-f932-423e-8cba-7b04ee5cd3f7", "5102f28d-8ff4-4071-896c-08afda28539e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5227b3ff-a012-4d7d-9cc8-16066b6cf8bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd13b872-f932-423e-8cba-7b04ee5cd3f7");
        }
    }
}
