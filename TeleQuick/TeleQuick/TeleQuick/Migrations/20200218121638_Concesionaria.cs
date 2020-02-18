using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class Concesionaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainForm",
                table: "Concessionaries",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Concessionaries",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainForm",
                table: "Concessionaries");

            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Concessionaries");
        }
    }
}
