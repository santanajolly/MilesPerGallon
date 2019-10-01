﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MilesPerGallon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Input",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    CarModel = table.Column<string>(nullable: false),
                    MilesDriven = table.Column<float>(nullable: false),
                    FillUpDate = table.Column<DateTime>(nullable: false),
                    GallonsFilled = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Input");
        }
    }
}
