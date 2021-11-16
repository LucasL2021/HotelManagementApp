using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateRoomTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ROOMS_RoomId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CUSTOMERS");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RoomId",
                table: "CUSTOMERS",
                newName: "IX_CUSTOMERS_RoomId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "ROOMTYPES",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "ROOMS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId",
                principalTable: "ROOMTYPES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "ROOMS");

            migrationBuilder.RenameTable(
                name: "CUSTOMERS",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "Customers",
                newName: "IX_Customers_RoomId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rent",
                table: "ROOMTYPES",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ROOMS_RoomId",
                table: "Customers",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
