using TeachersBingoApi.Data;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;

namespace TeachersBingoApi.Repositories.Implementations;

public class LeaderboardPositionRepository : ILeaderboardPositionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public LeaderboardPositionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddLeaderboardPosition(LeaderboardPosition leaderboardPosition)
    {
        _dbContext.LeaderboardPositions.Add(leaderboardPosition);
        _dbContext.SaveChanges();
    }
}
