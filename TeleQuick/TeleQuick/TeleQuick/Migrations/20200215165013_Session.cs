using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class Session : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Concessionaries",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccountSession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LoginUser = table.Column<string>(maxLength: 50, nullable: false),
                    LoginUserPassword = table.Column<string>(maxLength: 50, nullable: false),
                    ConcessionaryId = table.Column<int>(nullable: true),
                    AccountUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSession_UserAccounts_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountSession_Concessionaries_ConcessionaryId",
                        column: x => x.ConcessionaryId,
                        principalTable: "Concessionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountSession_AccountUserId",
                table: "AccountSession",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSession_ConcessionaryId",
                table: "AccountSession",
                column: "ConcessionaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSession");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Concessionaries");
        }
    }
}
