using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CheckMIg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFile_AspNetUsers_UserId",
                table: "UserFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFile_Files_FileId",
                table: "UserFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFile",
                table: "UserFile");

            migrationBuilder.RenameTable(
                name: "UserFile",
                newName: "UserToFiles");

            migrationBuilder.RenameIndex(
                name: "IX_UserFile_FileId",
                table: "UserToFiles",
                newName: "IX_UserToFiles_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToFiles",
                table: "UserToFiles",
                columns: new[] { "UserId", "FileId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserToFiles_AspNetUsers_UserId",
                table: "UserToFiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToFiles_Files_FileId",
                table: "UserToFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToFiles_AspNetUsers_UserId",
                table: "UserToFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToFiles_Files_FileId",
                table: "UserToFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToFiles",
                table: "UserToFiles");

            migrationBuilder.RenameTable(
                name: "UserToFiles",
                newName: "UserFile");

            migrationBuilder.RenameIndex(
                name: "IX_UserToFiles_FileId",
                table: "UserFile",
                newName: "IX_UserFile_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFile",
                table: "UserFile",
                columns: new[] { "UserId", "FileId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFile_AspNetUsers_UserId",
                table: "UserFile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFile_Files_FileId",
                table: "UserFile",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
