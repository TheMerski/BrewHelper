using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Batch_Size = table.Column<double>(type: "float", nullable: false),
                    Boil_Size = table.Column<double>(type: "float", nullable: false),
                    Tun_Volume = table.Column<double>(type: "float", nullable: true),
                    Tun_Weight = table.Column<double>(type: "float", nullable: true),
                    Tun_Specific_Heat = table.Column<double>(type: "float", nullable: true),
                    Top_Up_Water = table.Column<double>(type: "float", nullable: true),
                    Trub_Chiller_Loss = table.Column<double>(type: "float", nullable: true),
                    Evap_Rate = table.Column<double>(type: "float", nullable: true),
                    Boil_Time = table.Column<double>(type: "float", nullable: true),
                    Calc_Boil_Volume = table.Column<bool>(type: "bit", nullable: true),
                    Lauter_Deadspace = table.Column<double>(type: "float", nullable: true),
                    Top_Up_Kettle = table.Column<double>(type: "float", nullable: true),
                    Hop_Utilization = table.Column<bool>(type: "bit", nullable: true),
                    Display_Boil_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Batch_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Tun_Volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Tun_Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Top_Up_Water = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Trub_Chiller_Loss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Lauter_Deadspace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Top_Up_Kettle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Fermentables",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Yield = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<double>(type: "float", nullable: false),
                    Add_After_Boil = table.Column<bool>(type: "bit", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coarse_Fine_Diff = table.Column<double>(type: "float", nullable: true),
                    Moisture = table.Column<double>(type: "float", nullable: true),
                    Diastatic_Power = table.Column<double>(type: "float", nullable: true),
                    Protein = table.Column<double>(type: "float", nullable: true),
                    Max_In_Batch = table.Column<double>(type: "float", nullable: true),
                    Recommended_Mash = table.Column<bool>(type: "bit", nullable: true),
                    Ibu_Gal_Per_Lb = table.Column<double>(type: "float", nullable: true),
                    Display_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potential = table.Column<double>(type: "float", nullable: true),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentables", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Hops",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Alpha = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Use = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Form = table.Column<int>(type: "int", nullable: true),
                    Beta = table.Column<double>(type: "float", nullable: true),
                    HSI = table.Column<double>(type: "float", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Substitutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Humulene = table.Column<double>(type: "float", nullable: true),
                    Caryophyllene = table.Column<double>(type: "float", nullable: true),
                    Cohumulone = table.Column<double>(type: "float", nullable: true),
                    Myrcene = table.Column<double>(type: "float", nullable: true),
                    Display_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hops", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Miscs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Use = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Amount_Is_Weight = table.Column<bool>(type: "bit", nullable: true),
                    Use_For = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscs", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeXml = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style_Letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style_Guide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OG_Max = table.Column<double>(type: "float", nullable: false),
                    OG_Min = table.Column<double>(type: "float", nullable: false),
                    IBU_Min = table.Column<double>(type: "float", nullable: false),
                    IBU_Max = table.Column<double>(type: "float", nullable: false),
                    Color_Min = table.Column<double>(type: "float", nullable: false),
                    Color_Max = table.Column<double>(type: "float", nullable: false),
                    Carb_Min = table.Column<double>(type: "float", nullable: true),
                    Carb_Max = table.Column<double>(type: "float", nullable: true),
                    Abv_Min = table.Column<double>(type: "float", nullable: true),
                    Abv_Max = table.Column<double>(type: "float", nullable: true),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_OG_Min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_OG_Max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_FG_Min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_FG_Max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Color_Min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Color_Max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OG_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FG_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBU_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carb_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABV_Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Water",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Calcium = table.Column<double>(type: "float", nullable: false),
                    Bicarbonate = table.Column<double>(type: "float", nullable: false),
                    Sulfate = table.Column<double>(type: "float", nullable: false),
                    Chloride = table.Column<double>(type: "float", nullable: false),
                    Sodium = table.Column<double>(type: "float", nullable: false),
                    Magnesium = table.Column<double>(type: "float", nullable: false),
                    PH = table.Column<double>(type: "float", nullable: true),
                    Display_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "Yeasts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Amount_Is_Weight = table.Column<bool>(type: "bit", nullable: true),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min_Temperature = table.Column<double>(type: "float", nullable: true),
                    Max_Temperature = table.Column<double>(type: "float", nullable: true),
                    Flocculation = table.Column<int>(type: "int", nullable: true),
                    Attenuation = table.Column<double>(type: "float", nullable: true),
                    Best_For = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Times_Cultured = table.Column<int>(type: "int", nullable: true),
                    Max_Reuse = table.Column<int>(type: "int", nullable: true),
                    Add_To_Secondary = table.Column<bool>(type: "bit", nullable: true),
                    Display_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Min_Temp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display_Max_Temp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowInvalidSerialization = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeasts", x => new { x.Name, x.Version });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Fermentables");

            migrationBuilder.DropTable(
                name: "Hops");

            migrationBuilder.DropTable(
                name: "Miscs");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Water");

            migrationBuilder.DropTable(
                name: "Yeasts");
        }
    }
}
