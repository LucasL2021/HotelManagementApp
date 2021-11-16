using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Updateservicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "RoomNO",
                table: "SERVICES",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_RoomNO",
                table: "SERVICES",
                column: "RoomNO");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICES_ROOMS_RoomNO",
                table: "SERVICES",
                column: "RoomNO",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICES_ROOMS_RoomNO",
                table: "SERVICES");

            migrationBuilder.DropIndex(
                name: "IX_SERVICES_RoomNO",
                table: "SERVICES");

            migrationBuilder.AlterColumn<int>(
                name: "RoomNO",
                table: "SERVICES",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
