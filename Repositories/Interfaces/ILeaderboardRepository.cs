using TeachersBingoApi.Models;

namespace TeachersBingoApi.Repositories.Interfaces;

public interface ILeaderboardRepository
{
    Leaderboard GetLeaderboardById(int leaderboardId);
    void SaveChanges();
}
