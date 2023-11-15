using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Services.Interfaces;

public interface IPlayerService
{
    bool DoesPlayerExistByName(string name);
    Player CreatePlayer(string playerName);
    int AddPlayerToCurrentBingoGame(string playerName);
}
