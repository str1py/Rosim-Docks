using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class DockType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DockTypeId",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_DockTypeId",
                table: "Request",
                column: "DockTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_DocType_DockTypeId",
                table: "Request",
                column: "DockTypeId",
                principalTable: "DocType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_DocType_DockTypeId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_DockTypeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "DockTypeId",
                table: "Request");
        }
    }
}
