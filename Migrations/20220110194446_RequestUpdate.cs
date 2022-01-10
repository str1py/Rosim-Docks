using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class RequestUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyCount",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyCount",
                table: "Request");
        }
    }
}
