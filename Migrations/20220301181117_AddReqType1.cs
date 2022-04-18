using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class AddReqType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReqTypeId",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_ReqTypeId",
                table: "Request",
                column: "ReqTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestType_ReqTypeId",
                table: "Request",
                column: "ReqTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestType_ReqTypeId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ReqTypeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ReqTypeId",
                table: "Request");
        }
    }
}
