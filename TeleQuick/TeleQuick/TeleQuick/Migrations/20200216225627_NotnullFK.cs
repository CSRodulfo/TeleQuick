using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class NotnullFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions");

            migrationBuilder.AlterColumn<int>(
                name: "ConcessionaryId",
                table: "AccountSessions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions",
                column: "ConcessionaryId",
                principalTable: "Concessionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions");

            migrationBuilder.AlterColumn<int>(
                name: "ConcessionaryId",
                table: "AccountSessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions",
                column: "ConcessionaryId",
                principalTable: "Concessionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
