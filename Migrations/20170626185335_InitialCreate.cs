using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demoken.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlySales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BluRays = table.Column<decimal>(nullable: false),
                    DVDs = table.Column<decimal>(nullable: false),
                    Month = table.Column<string>(nullable: true),
                    VideoGames = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlySales");
        }
    }
}
