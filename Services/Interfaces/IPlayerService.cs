using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Services.Interfaces;

public interface IPlayerService
{
    void TogglePlayerChoice(string playerName, int bingoGameId, CoordinatesDTO coordinates);
    Player GetPlayerByName(string name);
    bool DoesPlayerExistByName(string name);
    Player CreatePlayer(string playerName);
    int AddPlayerToCurrentBingoGame(string playerName);
    bool CheckIfPlayerWon(string playerName);
}
