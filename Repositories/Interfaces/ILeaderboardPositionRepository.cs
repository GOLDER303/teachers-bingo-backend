using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Repositories.Interfaces;

public interface ILeaderboardPositionRepository
{
    void AddLeaderboardPosition(LeaderboardPosition leaderboardPosition);
    void RemoveLeaderboardPositionByLeaderboardIdAndPlayerId(int leaderboardId, int playerId);
    List<GeneralLeaderboardPositionDTO> GetAllLeaderboardPositionsAsDTOs();
}
