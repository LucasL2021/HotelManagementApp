using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCustomertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CUSTOMERS");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_RoomNo",
                table: "CUSTOMERS",
                column: "RoomNo");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomNo",
                table: "CUSTOMERS",
                column: "RoomNo",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomNo",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_RoomNo",
                table: "CUSTOMERS");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "CUSTOMERS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "CUSTOMERS",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
