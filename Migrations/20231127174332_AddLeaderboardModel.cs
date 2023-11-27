using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersBingoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaderboardModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaderboardId",
                table: "BingoGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeaderboardPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    LeaderboardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderboardPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderboardPositions_Leaderboards_LeaderboardId",
                        column: x => x.LeaderboardId,
                        principalTable: "Leaderboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderboardPositions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BingoGames_LeaderboardId",
                table: "BingoGames",
                column: "LeaderboardId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderboardPositions_LeaderboardId",
                table: "LeaderboardPositions",
                column: "LeaderboardId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderboardPositions_PlayerId",
                table: "LeaderboardPositions",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BingoGames_Leaderboards_LeaderboardId",
                table: "BingoGames",
                column: "LeaderboardId",
                principalTable: "Leaderboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BingoGames_Leaderboards_LeaderboardId",
                table: "BingoGames");

            migrationBuilder.DropTable(
                name: "LeaderboardPositions");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropIndex(
                name: "IX_BingoGames_LeaderboardId",
                table: "BingoGames");

            migrationBuilder.DropColumn(
                name: "LeaderboardId",
                table: "BingoGames");
        }
    }
}
