using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    public partial class AddMiscStockAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StockAmount",
                table: "Miscs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "Miscs");
        }
    }
}
