using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileEntityUserEntity");

            migrationBuilder.CreateTable(
                name: "UserFile",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFile", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_UserFile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFile_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFile_FileId",
                table: "UserFile",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFile");

            migrationBuilder.CreateTable(
                name: "FileEntityUserEntity",
                columns: table => new
                {
                    FilesId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileEntityUserEntity", x => new { x.FilesId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_FileEntityUserEntity_AspNetUsers_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileEntityUserEntity_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileEntityUserEntity_OwnersId",
                table: "FileEntityUserEntity",
                column: "OwnersId");
        }
    }
}
