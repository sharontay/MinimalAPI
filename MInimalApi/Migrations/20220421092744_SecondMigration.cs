﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MInimalApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorbikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    MelfunctionChance = table.Column<double>(type: "float", nullable: false),
                    MelfunctionsOccured = table.Column<int>(type: "int", nullable: false),
                    DistanceCoverdInMiles = table.Column<int>(type: "int", nullable: false),
                    FinishedRace = table.Column<bool>(type: "bit", nullable: false),
                    RacedForHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorbikes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorbikes");
        }
    }
}
