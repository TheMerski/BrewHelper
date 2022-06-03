using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    public partial class AddYeastStockAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StockAmount",
                table: "Yeasts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "Yeasts");
        }
    }
}
