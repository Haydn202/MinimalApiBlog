using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContentUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ContentUrl", "CreatedOn", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("7464b48b-9c62-439c-b5c4-9a465bf944ed"), "I'm an article", new DateTime(2023, 9, 2, 15, 58, 10, 263, DateTimeKind.Local).AddTicks(7410), "test article 1", "article 1" },
                    { new Guid("a77fe743-1f20-46c1-89a8-0d75c75edded"), "I'm an article", new DateTime(2023, 9, 2, 15, 58, 10, 263, DateTimeKind.Local).AddTicks(7500), "test article 2", "article 2" },
                    { new Guid("b90c3da7-8da8-4c2b-884e-eba7c6ac0b39"), "I'm an article", new DateTime(2023, 9, 2, 15, 58, 10, 263, DateTimeKind.Local).AddTicks(7510), "test article 3", "article 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
