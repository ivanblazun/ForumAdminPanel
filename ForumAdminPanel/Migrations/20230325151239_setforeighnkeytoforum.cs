using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumAdminPanel.Migrations
{
    public partial class setforeighnkeytoforum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Foras_ForumId",
                table: "Themes",
                column: "ForumId",
                principalTable: "Fora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Foras_ForumId",
                table: "Themes");

            migrationBuilder.DropTable(
                name: "Foras");

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemesCounter = table.Column<int>(type: "int", nullable: false),
                    UserCounter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Forums_ForumId",
                table: "Themes",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
