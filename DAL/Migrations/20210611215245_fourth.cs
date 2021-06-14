using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Files_FileEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FileEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FileEntityId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileEntityUserEntity");

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
    }
}
