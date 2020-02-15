using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class Sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSession_UserAccounts_AccountUserId",
                table: "AccountSession");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountSession_Concessionaries_ConcessionaryId",
                table: "AccountSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountSession",
                table: "AccountSession");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "AccountUsers");

            migrationBuilder.RenameTable(
                name: "AccountSession",
                newName: "AccountSessions");

            migrationBuilder.RenameIndex(
                name: "IX_AccountSession_ConcessionaryId",
                table: "AccountSessions",
                newName: "IX_AccountSessions_ConcessionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountSession_AccountUserId",
                table: "AccountSessions",
                newName: "IX_AccountSessions_AccountUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUsers",
                table: "AccountUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountSessions",
                table: "AccountSessions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSessions_AccountUsers_AccountUserId",
                table: "AccountSessions",
                column: "AccountUserId",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions",
                column: "ConcessionaryId",
                principalTable: "Concessionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSessions_AccountUsers_AccountUserId",
                table: "AccountSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountSessions_Concessionaries_ConcessionaryId",
                table: "AccountSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUsers",
                table: "AccountUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountSessions",
                table: "AccountSessions");

            migrationBuilder.RenameTable(
                name: "AccountUsers",
                newName: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "AccountSessions",
                newName: "AccountSession");

            migrationBuilder.RenameIndex(
                name: "IX_AccountSessions_ConcessionaryId",
                table: "AccountSession",
                newName: "IX_AccountSession_ConcessionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountSessions_AccountUserId",
                table: "AccountSession",
                newName: "IX_AccountSession_AccountUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountSession",
                table: "AccountSession",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSession_UserAccounts_AccountUserId",
                table: "AccountSession",
                column: "AccountUserId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSession_Concessionaries_ConcessionaryId",
                table: "AccountSession",
                column: "ConcessionaryId",
                principalTable: "Concessionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
