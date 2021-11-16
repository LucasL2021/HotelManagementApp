using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "ROOMS");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_RTCode",
                table: "ROOMS",
                column: "RTCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RTCode",
                table: "ROOMS",
                column: "RTCode",
                principalTable: "ROOMTYPES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RTCode",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RTCode",
                table: "ROOMS");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "ROOMS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId",
                principalTable: "ROOMTYPES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
