namespace TeachersBingoApi.Repositories.Interfaces;

using TeachersBingoApi.Models;

public interface IPlayerRepository
{
    Player GetPlayerByName(string name);
    bool DoesPlayerExistByName(string name);
    Player AddPlayer(Player player);
    void SaveChanges();
}
