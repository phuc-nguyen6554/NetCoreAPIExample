using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleAPI.Migrations
{
    public partial class addauthortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AuthorID",
                table: "books",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorID",
                table: "books",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_AuthorID",
                table: "books",
                column: "AuthorID",
                principalTable: "authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_AuthorID",
                table: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropIndex(
                name: "IX_books_AuthorID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "books");
        }
    }
}
