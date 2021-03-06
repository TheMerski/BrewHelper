using Microsoft.EntityFrameworkCore.Migrations;

namespace BrewHelper.Migrations
{
    public partial class AddIngredientInStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InStock",
                table: "Ingredients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Ingredients");
        }
    }
}
