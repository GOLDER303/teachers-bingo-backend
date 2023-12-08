using Microsoft.EntityFrameworkCore;
using TeachersBingoApi.Data;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;

namespace TeachersBingoApi.Repositories.Implementations;

public class BingoGameRepository : IBingoGameRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BingoGameRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BingoGame? GetLatestBingoGameByBingo(Bingo bingo)
    {
        var lastBingoGame = _dbContext
            .BingoGames
            .Where(bg => bg.Bingo == bingo)
            .OrderByDescending(bg => bg.EndDateTime)
            .FirstOrDefault();

        return lastBingoGame;
    }

    public BingoGame GetBingoGameWithLeaderboardById(int bingoGameId)
    {
        var bingoGame =
            _dbContext.BingoGames.Include(bg => bg.Leaderboard).FirstOrDefault(bg => bg.Id == bingoGameId)
            ?? throw new KeyNotFoundException($"BingoGame with id: {bingoGameId} not found");

        return bingoGame;
    }

    public void AddBingoGame(BingoGame bingoGame)
    {
        _dbContext.BingoGames.Add(bingoGame);
        _dbContext.SaveChanges();
    }
}
