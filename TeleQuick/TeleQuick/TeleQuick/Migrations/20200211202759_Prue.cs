using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class Prue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserAccounts",
                table: "AppUserAccounts");

            migrationBuilder.RenameTable(
                name: "AppUserAccounts",
                newName: "UserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "AppUserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserAccounts",
                table: "AppUserAccounts",
                column: "Id");
        }
    }
}
