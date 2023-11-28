using TeachersBingoApi.Models;

namespace TeachersBingoApi.Repositories.Interfaces;

public interface ILeaderboardPositionRepository
{
    void AddLeaderboardPosition(LeaderboardPosition leaderboardPosition);
}
