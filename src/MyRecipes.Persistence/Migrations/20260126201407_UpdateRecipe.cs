using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfServings",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreparationTime",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfServings",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "Recipe");
        }
    }
}
