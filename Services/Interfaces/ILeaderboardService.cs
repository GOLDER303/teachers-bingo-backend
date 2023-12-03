using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Services.Interfaces;

public interface ILeaderboardService
{
    void AddPlayerToLeaderboard(Player player, int leaderboardId);
    bool UpdatePlayerInLeaderboard(Player player, int leaderboardId);
    void RemovePlayerFromLeaderboard(Player player, int leaderboardId);
    bool IsPlayerInLeaderboard(Player player, int leaderboardId);
    GeneralLeaderboardDTO GetGeneralLeaderboard();
}
