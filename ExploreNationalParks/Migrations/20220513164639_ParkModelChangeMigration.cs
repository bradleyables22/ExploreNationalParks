using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExploreNationalParks.Migrations
{
    public partial class ParkModelChangeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Visitors",
                table: "nationalParks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "nationalParks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "nationalParks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "Km2",
                table: "nationalParks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "Acres",
                table: "nationalParks",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Visitors",
                table: "nationalParks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "nationalParks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "nationalParks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Km2",
                table: "nationalParks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "Acres",
                table: "nationalParks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }
    }
}
