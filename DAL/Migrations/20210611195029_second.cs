using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FileEntityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FileEntityId",
                table: "AspNetUsers",
                column: "FileEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Files_FileEntityId",
                table: "AspNetUsers",
                column: "FileEntityId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Files_FileEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FileEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileEntityId",
                table: "AspNetUsers");
        }
    }
}
