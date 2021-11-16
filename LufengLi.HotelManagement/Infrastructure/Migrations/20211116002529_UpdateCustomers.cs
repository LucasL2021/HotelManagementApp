using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS");

            migrationBuilder.RenameTable(
                name: "CUSTOMERS",
                newName: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ROOMS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckIn",
                table: "Customers",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Advance",
                table: "Customers",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_CustomerId",
                table: "ROOMS",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_Customers_CustomerId",
                table: "ROOMS",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_Customers_CustomerId",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_CustomerId",
                table: "ROOMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ROOMS");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CUSTOMERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckIn",
                table: "CUSTOMERS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Advance",
                table: "CUSTOMERS",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS",
                column: "Id");
        }
    }
}
