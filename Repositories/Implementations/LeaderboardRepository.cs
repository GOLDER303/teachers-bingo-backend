using TeachersBingoApi.Data;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;

namespace TeachersBingoApi.Repositories.Implementations;

public class LeaderboardRepository : ILeaderboardRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LeaderboardRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Leaderboard GetLeaderboardById(int leaderboardId)
    {
        var leaderboard =
            _dbContext.Leaderboards.FirstOrDefault(l => l.Id == leaderboardId)
            ?? throw new KeyNotFoundException($"Leaderboard with id: {leaderboardId} not found");

        return leaderboard;
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}
