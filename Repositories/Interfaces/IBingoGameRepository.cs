using TeachersBingoApi.Models;

namespace TeachersBingoApi.Repositories.Interfaces;

public interface IBingoGameRepository
{
    BingoGame? GetLatestBingoGameByBingo(Bingo bingo);
    BingoGame GetBingoGameWithLeaderboardById(int bingoGameId);
    void AddBingoGame(BingoGame bingoGame);
}
