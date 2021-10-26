using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class NoteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImportanceId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ImportanceId",
                table: "Notes",
                column: "ImportanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Importance_ImportanceId",
                table: "Notes",
                column: "ImportanceId",
                principalTable: "Importance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Importance_ImportanceId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ImportanceId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ImportanceId",
                table: "Notes");
        }
    }
}
