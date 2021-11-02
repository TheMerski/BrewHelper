using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrewHelper.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeStepId = table.Column<long>(type: "bigint", nullable: false),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    AddAfter = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.RecipeStepId, x.Id });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_RecipeSteps_RecipeStepId",
                        column: x => x.RecipeStepId,
                        principalTable: "RecipeSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartSG = table.Column<int>(type: "int", nullable: false),
                    EndSG = table.Column<int>(type: "int", nullable: false),
                    Yield = table.Column<int>(type: "int", nullable: false),
                    ReadyAfter = table.Column<long>(type: "bigint", nullable: false),
                    AlcoholPercentage = table.Column<double>(type: "float", nullable: false),
                    IBU = table.Column<double>(type: "float", nullable: false),
                    EBC = table.Column<double>(type: "float", nullable: false),
                    MashWater = table.Column<double>(type: "float", nullable: false),
                    RinseWater = table.Column<double>(type: "float", nullable: false),
                    MashingId = table.Column<long>(type: "bigint", nullable: true),
                    BoilingId = table.Column<long>(type: "bigint", nullable: true),
                    YeastingId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeSteps_BoilingId",
                        column: x => x.BoilingId,
                        principalTable: "RecipeSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeSteps_MashingId",
                        column: x => x.MashingId,
                        principalTable: "RecipeSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeSteps_YeastingId",
                        column: x => x.YeastingId,
                        principalTable: "RecipeSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StepLogs_PhMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepLogId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepLogs_PhMeasurements", x => new { x.StepLogId, x.Id });
                    table.ForeignKey(
                        name: "FK_StepLogs_PhMeasurements_StepLogs_StepLogId",
                        column: x => x.StepLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepLogs_SgMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepLogId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepLogs_SgMeasurements", x => new { x.StepLogId, x.Id });
                    table.ForeignKey(
                        name: "FK_StepLogs_SgMeasurements_StepLogs_StepLogId",
                        column: x => x.StepLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepLogs_TemperatureMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepLogId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepLogs_TemperatureMeasurements", x => new { x.StepLogId, x.Id });
                    table.ForeignKey(
                        name: "FK_StepLogs_TemperatureMeasurements_StepLogs_StepLogId",
                        column: x => x.StepLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrewLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartSG = table.Column<int>(type: "int", nullable: true),
                    EndSG = table.Column<int>(type: "int", nullable: true),
                    AlcoholPercentage = table.Column<double>(type: "float", nullable: true),
                    Yield = table.Column<double>(type: "float", nullable: true),
                    IBU = table.Column<double>(type: "float", nullable: true),
                    EBC = table.Column<double>(type: "float", nullable: true),
                    MashingLogId = table.Column<long>(type: "bigint", nullable: true),
                    BoilingLogId = table.Column<long>(type: "bigint", nullable: true),
                    YeastingLogId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewLogs_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrewLogs_StepLogs_BoilingLogId",
                        column: x => x.BoilingLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrewLogs_StepLogs_MashingLogId",
                        column: x => x.MashingLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrewLogs_StepLogs_YeastingLogId",
                        column: x => x.YeastingLogId,
                        principalTable: "StepLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrewLogs_BoilingLogId",
                table: "BrewLogs",
                column: "BoilingLogId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewLogs_MashingLogId",
                table: "BrewLogs",
                column: "MashingLogId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewLogs_RecipeId",
                table: "BrewLogs",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewLogs_YeastingLogId",
                table: "BrewLogs",
                column: "YeastingLogId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BoilingId",
                table: "Recipes",
                column: "BoilingId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MashingId",
                table: "Recipes",
                column: "MashingId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_YeastingId",
                table: "Recipes",
                column: "YeastingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewLogs");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "StepLogs_PhMeasurements");

            migrationBuilder.DropTable(
                name: "StepLogs_SgMeasurements");

            migrationBuilder.DropTable(
                name: "StepLogs_TemperatureMeasurements");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "StepLogs");

            migrationBuilder.DropTable(
                name: "RecipeSteps");
        }
    }
}
