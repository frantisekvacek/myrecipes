using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyRecipes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Index", "Name", "Picture", "Visibility" },
                values: new object[,]
                {
                    { new Guid("05457a86-e2b0-4b5c-90d4-9fb657b10449"), 1, "Polievky a prílohy", "", true },
                    { new Guid("6d4ca1ca-bba5-45f3-890f-2ffcdf400bb8"), 4, "Sviatočné jedlá", "", true },
                    { new Guid("77bd497a-9a8c-40e1-aec5-a03d82292e10"), 5, "Všetky recepty", "", true },
                    { new Guid("ae3289c8-3ad3-48e8-9ed3-b3ece7be5c03"), 2, "Raňajky a večere", "", true },
                    { new Guid("ed101e92-c1d3-494e-824f-f208af796cfd"), 3, "Sladké a slané", "", true },
                    { new Guid("ef34d609-1f2d-4863-ab67-1dc4dd822333"), 0, "Hlavné jedlá", "", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
