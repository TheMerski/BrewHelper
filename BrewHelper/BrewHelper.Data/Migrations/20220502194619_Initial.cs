using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fermentables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StockAmount = table.Column<long>(type: "bigint", nullable: false),
                    Yield = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Miscs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Use = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscs", x => x.Id);
                });

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
                name: "Yeasts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopIngredient",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Use = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopIngredient", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_HopIngredient_Hops_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopIngredient_Recipes_RecipeId",
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
                    StepTime = table.Column<int>(type: "int", nullable: false),
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
                name: "RecipeIngredient<Fermentable>",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient<Fermentable>", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Fermentable>_Fermentables_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Fermentables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Fermentable>_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient<Misc>",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient<Misc>", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Misc>_Miscs_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Miscs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Misc>_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient<Water>",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingredient_Calcium = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Bicarbonate = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Sulfate = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Chloride = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Sodium = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Magnesium = table.Column<double>(type: "float", nullable: false),
                    Ingredient_Id = table.Column<long>(type: "bigint", nullable: false),
                    Ingredient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredient_Version = table.Column<int>(type: "int", nullable: false),
                    Ingredient_Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient<Water>", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Water>_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient<Yeast>",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient<Yeast>", x => new { x.RecipeId, x.Id });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Yeast>_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient<Yeast>_Yeasts_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Yeasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopIngredient_IngredientId",
                table: "HopIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient<Fermentable>_IngredientId",
                table: "RecipeIngredient<Fermentable>",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient<Misc>_IngredientId",
                table: "RecipeIngredient<Misc>",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient<Yeast>_IngredientId",
                table: "RecipeIngredient<Yeast>",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopIngredient");

            migrationBuilder.DropTable(
                name: "MashStep");

            migrationBuilder.DropTable(
                name: "RecipeIngredient<Fermentable>");

            migrationBuilder.DropTable(
                name: "RecipeIngredient<Misc>");

            migrationBuilder.DropTable(
                name: "RecipeIngredient<Water>");

            migrationBuilder.DropTable(
                name: "RecipeIngredient<Yeast>");

            migrationBuilder.DropTable(
                name: "Hops");

            migrationBuilder.DropTable(
                name: "Fermentables");

            migrationBuilder.DropTable(
                name: "Miscs");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Yeasts");
        }
    }
}
