using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersBingoApi.Migrations
{
    /// <inheritdoc />
    public partial class FixPlayerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBingoGameId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentBingoGameId",
                table: "Players",
                column: "CurrentBingoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players",
                column: "CurrentBingoGameId",
                principalTable: "BingoGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CurrentBingoGameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentBingoGameId",
                table: "Players");
        }
    }
}
