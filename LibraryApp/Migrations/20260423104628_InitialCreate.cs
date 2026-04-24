using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.CheckConstraint("CK_Books_Genre", "\"Genre\" IN ('Fiction','NonFiction','Mystery','Thriller',  'SciFi','Fantasy','Romance','Horror',  'Biography','History','SelfHelp','Technology')");
                    table.CheckConstraint("CK_Books_Pages", "\"Pages\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedAt", "Description", "Genre", "Pages", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A handbook of agile software craftsmanship", "Technology", 431, "Clean Code" },
                    { 2, "David Thomas", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Your journey to mastery", "Technology", 352, "The Pragmatic Programmer" },
                    { 3, "Frank Herbert", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A science fiction masterpiece", "SciFi", 688, "Dune" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedAt", "Note" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "This book changed the way I write code completely" },
                    { 2, 1, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Must read for every software developer out there" },
                    { 3, 3, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dune is an absolute masterpiece of world building" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
