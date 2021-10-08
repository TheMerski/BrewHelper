using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrewHelper.Migrations
{
    public partial class AddBrewLogEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StepLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "StepLogs_PhMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepLogId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewLogs");

            migrationBuilder.DropTable(
                name: "StepLogs_PhMeasurements");

            migrationBuilder.DropTable(
                name: "StepLogs_SgMeasurements");

            migrationBuilder.DropTable(
                name: "StepLogs_TemperatureMeasurements");

            migrationBuilder.DropTable(
                name: "StepLogs");
        }
    }
}
