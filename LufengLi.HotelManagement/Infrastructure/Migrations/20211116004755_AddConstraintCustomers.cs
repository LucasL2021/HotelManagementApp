using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddConstraintCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_Customers_CustomerId",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_CustomerId",
                table: "ROOMS");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ROOMS");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RoomId",
                table: "Customers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ROOMS_RoomId",
                table: "Customers",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ROOMS_RoomId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RoomId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ROOMS",
                type: "int",
                nullable: true);

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
    }
}
