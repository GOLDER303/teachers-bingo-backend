using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Services.Implementations;

public class LeaderboardService : ILeaderboardService
{
    private readonly ILeaderboardRepository _leaderboardRepository;
    private readonly ILeaderboardPositionRepository _leaderboardPositionRepository;

    public LeaderboardService(ILeaderboardRepository leaderboardRepository, ILeaderboardPositionRepository leaderboardPositionRepository)
    {
        _leaderboardRepository = leaderboardRepository;
        _leaderboardPositionRepository = leaderboardPositionRepository;
    }

    public void AddPlayerToLeaderboard(Player player, int leaderboardId)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboardById(leaderboardId);

        if (IsPlayerInLeaderboard(player, leaderboard.Id))
        {
            return;
        }

        int position = leaderboard.Positions.Count + 1;

        LeaderboardPosition newLeaderboardPosition = new()
        {
            Position = position,
            Player = player,
            Leaderboard = leaderboard,
        };

        _leaderboardPositionRepository.AddLeaderboardPosition(newLeaderboardPosition);

        leaderboard.Positions.Add(newLeaderboardPosition);

        _leaderboardRepository.SaveChanges();
    }

    public bool IsPlayerInLeaderboard(Player player, int leaderboardId)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboardById(leaderboardId);
        var isPlayerInLeaderboard = leaderboard.Positions.Any(p => p.Player.Id == player.Id);
        return isPlayerInLeaderboard;
    }
}
