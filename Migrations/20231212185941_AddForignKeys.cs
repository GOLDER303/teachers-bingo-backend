using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersBingoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentBingoGameId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players",
                column: "CurrentBingoGameId",
                principalTable: "BingoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentBingoGameId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_BingoGames_CurrentBingoGameId",
                table: "Players",
                column: "CurrentBingoGameId",
                principalTable: "BingoGames",
                principalColumn: "Id");
        }
    }
}
