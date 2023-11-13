namespace TeachersBingoApi.Repositories.Interfaces;

using TeachersBingoApi.Models;

public interface IPlayerRepository
{
    Player GetPlayerByName(string name);
    bool DoesPlayerExistByName(string name);
    Player CreatePlayer(string name);
    void SaveChanges();
}