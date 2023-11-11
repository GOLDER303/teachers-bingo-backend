using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeachersBingoApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedBingoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bingos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bingo 1" });

            migrationBuilder.InsertData(
                table: "Phrase",
                columns: new[] { "Id", "BingoId", "Content" },
                values: new object[,]
                {
                    { 1, 1, "Phrase 1" },
                    { 2, 1, "Phrase 2" },
                    { 3, 1, "Phrase 3" },
                    { 4, 1, "Phrase 4" },
                    { 5, 1, "Phrase 5" },
                    { 6, 1, "Phrase 6" },
                    { 7, 1, "Phrase 7" },
                    { 8, 1, "Phrase 8" },
                    { 9, 1, "Phrase 9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Phrase",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bingos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
