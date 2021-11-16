using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ServiceDate",
                table: "SERVICES",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SERVICES",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SERVICES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_RoomId",
                table: "SERVICES",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICES_ROOMS_RoomId",
                table: "SERVICES",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICES_ROOMS_RoomId",
                table: "SERVICES");

            migrationBuilder.DropIndex(
                name: "IX_SERVICES_RoomId",
                table: "SERVICES");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SERVICES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ServiceDate",
                table: "SERVICES",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SERVICES",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);
        }
    }
}
