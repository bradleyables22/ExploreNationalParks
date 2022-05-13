using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExploreNationalParks.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nationalParks",
                columns: table => new
                {
                    ParkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Acres = table.Column<int>(type: "INTEGER", nullable: false),
                    Km2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Longitude = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEstablished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", maxLength: 1200, nullable: false),
                    NpsLink = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Visitors = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalParks", x => x.ParkID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nationalParks");
        }
    }
}
