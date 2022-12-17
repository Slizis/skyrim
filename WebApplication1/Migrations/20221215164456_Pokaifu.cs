using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Pokaifu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Players_PalyerId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "PalyerId",
                table: "Weapons",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_PalyerId",
                table: "Weapons",
                newName: "IX_Weapons_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Weapons",
                newName: "PalyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_PlayerId",
                table: "Weapons",
                newName: "IX_Weapons_PalyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Players_PalyerId",
                table: "Weapons",
                column: "PalyerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
