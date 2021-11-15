using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class UpdateRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Request",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Request_CreateUserId",
                table: "Request",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_CreateUserId",
                table: "Request",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_CreateUserId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_CreateUserId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Request");
        }
    }
}
