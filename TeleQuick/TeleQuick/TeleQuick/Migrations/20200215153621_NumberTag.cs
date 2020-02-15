using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class NumberTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TagRfids");

            migrationBuilder.DropColumn(
                name: "NumberTAG",
                table: "TagRfids");

            migrationBuilder.AddColumn<bool>(
                name: "TAGEneable",
                table: "TagRfids",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TAGNumber",
                table: "TagRfids",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TAGEneable",
                table: "TagRfids");

            migrationBuilder.DropColumn(
                name: "TAGNumber",
                table: "TagRfids");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TagRfids",
                type: "nvarchar(111)",
                maxLength: 111,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberTAG",
                table: "TagRfids",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0);
        }
    }
}
