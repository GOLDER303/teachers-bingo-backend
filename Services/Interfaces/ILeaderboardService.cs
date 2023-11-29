using TeachersBingoApi.Models;

namespace TeachersBingoApi.Services.Interfaces;

public interface ILeaderboardService
{
    void AddPlayerToLeaderboard(Player player, int leaderboardId);
    bool IsPlayerInLeaderboard(Player player, int leaderboardId);
}
