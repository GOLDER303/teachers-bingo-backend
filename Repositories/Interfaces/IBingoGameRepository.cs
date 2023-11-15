using TeachersBingoApi.Models;

namespace TeachersBingoApi.Repositories.Interfaces;

public interface IBingoGameRepository
{
    BingoGame? GetLatestBingoGameByBingo(Bingo bingo);
    void AddBingoGame(BingoGame bingoGame);
}
