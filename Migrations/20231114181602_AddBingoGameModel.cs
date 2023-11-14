using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersBingoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBingoGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BingoGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BingoId = table.Column<int>(type: "int", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BingoGames_Bingos_BingoId",
                        column: x => x.BingoId,
                        principalTable: "Bingos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BingoGamePlayer",
                columns: table => new
                {
                    BingoGamesId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoGamePlayer", x => new { x.BingoGamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_BingoGamePlayer_BingoGames_BingoGamesId",
                        column: x => x.BingoGamesId,
                        principalTable: "BingoGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BingoGamePlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BingoGamePlayer_PlayersId",
                table: "BingoGamePlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_BingoGames_BingoId",
                table: "BingoGames",
                column: "BingoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BingoGamePlayer");

            migrationBuilder.DropTable(
                name: "BingoGames");
        }
    }
}
