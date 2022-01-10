using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class NoteUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Notes",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatorId",
                table: "Notes",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_CreatorId",
                table: "Notes",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_CreatorId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CreatorId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Notes");
        }
    }
}
