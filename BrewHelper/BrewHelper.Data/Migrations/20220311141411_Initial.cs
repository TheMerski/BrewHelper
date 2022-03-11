using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Style_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style_CategoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style_StyleLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style_StyleGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style_Type = table.Column<int>(type: "int", nullable: false),
                    Style_OG_Max = table.Column<double>(type: "float", nullable: false),
                    Style_OG_Min = table.Column<double>(type: "float", nullable: false),
                    Style_IBU_Min = table.Column<double>(type: "float", nullable: false),
                    Style_IBU_Max = table.Column<double>(type: "float", nullable: false),
                    Style_ColorMin = table.Column<double>(type: "float", nullable: false),
                    Style_ColorMax = table.Column<double>(type: "float", nullable: false),
                    Style_Id = table.Column<long>(type: "bigint", nullable: false),
                    Style_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style_Version = table.Column<int>(type: "int", nullable: false),
                    Style_Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brewer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchSize = table.Column<double>(type: "float", nullable: false),
                    BoilSize = table.Column<double>(type: "float", nullable: false),
                    BoilTime = table.Column<double>(type: "float", nullable: false),
                    Mash_GrainTemp = table.Column<double>(type: "float", nullable: false),
                    Mash_Id = table.Column<long>(type: "bigint", nullable: false),
                    Mash_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mash_Version = table.Column<int>(type: "int", nullable: false),
                    Mash_Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fermentable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Yield = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentable", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Fermentable_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hop",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Alpha = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Use = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hop", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Hop_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MashStep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MashRecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StepTemp = table.Column<double>(type: "float", nullable: false),
                    StepTime = table.Column<double>(type: "float", nullable: false),
                    InfuseAmount = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MashStep", x => new { x.MashRecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_MashStep_Recipes_MashRecipeId",
                        column: x => x.MashRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Misc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Use = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misc", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Misc_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Water",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Calcium = table.Column<double>(type: "float", nullable: false),
                    Bicarbonate = table.Column<double>(type: "float", nullable: false),
                    Sulfate = table.Column<double>(type: "float", nullable: false),
                    Chloride = table.Column<double>(type: "float", nullable: false),
                    Sodium = table.Column<double>(type: "float", nullable: false),
                    Magnesium = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Water", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Water_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yeast",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeast", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_Yeast_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fermentable");

            migrationBuilder.DropTable(
                name: "Hop");

            migrationBuilder.DropTable(
                name: "MashStep");

            migrationBuilder.DropTable(
                name: "Misc");

            migrationBuilder.DropTable(
                name: "Water");

            migrationBuilder.DropTable(
                name: "Yeast");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
