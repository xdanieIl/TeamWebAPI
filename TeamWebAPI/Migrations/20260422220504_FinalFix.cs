using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FinalFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakFastFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakFastFoods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BreakFastFoods",
                columns: new[] { "Id", "Calories", "Category", "FoodName", "IsHealthy", "PreparationTime" },
                values: new object[] { 1, 100, "Savory", "Eggs", true, 2 });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Category", "HobbyName", "HoursPerWeek", "SkillLevel" },
                values: new object[] { 1, "Indoor", "Gaming", 12, "Easy" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "FullName", "YearInProgram" },
                values: new object[] { 1, new DateTime(2006, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Lorenzo Craig", "Sophomore" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Genre", "Platform", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 1, "Action", "PC", 9.5, 2013, "GTA V" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakFastFoods");

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
