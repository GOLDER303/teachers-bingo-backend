using Microsoft.EntityFrameworkCore;
using TeachersBingoApi.Data;
using TeachersBingoApi.Dtos;
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

    public List<LeaderboardPositionDTO> GetAllLeaderboardPositionsAsDTOs()
    {
        var allLeaderBoardPositionsDTOs = _dbContext.LeaderboardPositions
            .Include(lp => lp.Player)
            .GroupBy(lp => lp.Player.Name)
            .Select(group => new LeaderboardPositionDTO
            {
                PlayerName = group.Key,
                BingoWinsCount = group.Count(),
                Position = -1
            })
            .OrderByDescending(result => result.BingoWinsCount)
            .ToList();


        return allLeaderBoardPositionsDTOs;
    }

    public void RemoveLeaderboardPositionByLeaderboardIdAndPlayerId(int leaderboardId, int playerId)
    {
        var positionToRemove = _dbContext.LeaderboardPositions
            .FirstOrDefault(lp => lp.Leaderboard.Id == leaderboardId && lp.Player.Id == playerId);

        if (positionToRemove != null)
        {
            _dbContext.LeaderboardPositions.Remove(positionToRemove);
            _dbContext.SaveChanges();
        }
    }
}
