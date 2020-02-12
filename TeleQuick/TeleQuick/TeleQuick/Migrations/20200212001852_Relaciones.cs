using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleQuick.Migrations
{
    public partial class Relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Voucher",
                table: "InvoiceHeaders",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PointOfSale",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "IVARni",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IVARG3337",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IVAIns",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IIBB",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CAE",
                table: "InvoiceHeaders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "InvoiceHeaders",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "InvoiceDetails",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "InvoiceDetails",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceHeaderId",
                table: "InvoiceDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_VehicleId",
                table: "InvoiceHeaders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderId",
                table: "InvoiceDetails",
                column: "InvoiceHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceDetails",
                column: "InvoiceHeaderId",
                principalTable: "InvoiceHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_Vehicles_VehicleId",
                table: "InvoiceHeaders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_Vehicles_VehicleId",
                table: "InvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHeaders_VehicleId",
                table: "InvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "InvoiceHeaderId",
                table: "InvoiceDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Voucher",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Total",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Subtotal",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "PointOfSale",
                table: "InvoiceHeaders",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IVARni",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "IVARG3337",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "IVAIns",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "IIBB",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "CAE",
                table: "InvoiceHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "InvoiceDetails",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5);
        }
    }
}
