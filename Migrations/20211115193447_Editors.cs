using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RosreestDocks.Migrations
{
    public partial class Editors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Foiv",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditorId",
                table: "Foiv",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Agency",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditorId",
                table: "Agency",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Acronyms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditorId",
                table: "Acronyms",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Foiv_LastEditorId",
                table: "Foiv",
                column: "LastEditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_LastEditorId",
                table: "Agency",
                column: "LastEditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Acronyms_LastEditorId",
                table: "Acronyms",
                column: "LastEditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acronyms_AspNetUsers_LastEditorId",
                table: "Acronyms",
                column: "LastEditorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agency_AspNetUsers_LastEditorId",
                table: "Agency",
                column: "LastEditorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foiv_AspNetUsers_LastEditorId",
                table: "Foiv",
                column: "LastEditorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acronyms_AspNetUsers_LastEditorId",
                table: "Acronyms");

            migrationBuilder.DropForeignKey(
                name: "FK_Agency_AspNetUsers_LastEditorId",
                table: "Agency");

            migrationBuilder.DropForeignKey(
                name: "FK_Foiv_AspNetUsers_LastEditorId",
                table: "Foiv");

            migrationBuilder.DropIndex(
                name: "IX_Foiv_LastEditorId",
                table: "Foiv");

            migrationBuilder.DropIndex(
                name: "IX_Agency_LastEditorId",
                table: "Agency");

            migrationBuilder.DropIndex(
                name: "IX_Acronyms_LastEditorId",
                table: "Acronyms");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Foiv");

            migrationBuilder.DropColumn(
                name: "LastEditorId",
                table: "Foiv");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "LastEditorId",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Acronyms");

            migrationBuilder.DropColumn(
                name: "LastEditorId",
                table: "Acronyms");
        }
    }
}
