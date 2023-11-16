using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Services.Implementations;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IBingoGameService _bingoGameService;

    public PlayerService(IPlayerRepository playerRepository, IBingoGameService bingoGameService)
    {
        _playerRepository = playerRepository;
        _bingoGameService = bingoGameService;
    }

    public Player GetPlayerByName(string name)
    {
        return _playerRepository.GetPlayerByName(name);
    }

    public void TogglePlayerChoice(string playerName, int bingoGameId, CoordinatesDTO coordinates)
    {
        var player = _playerRepository.GetPlayerByName(playerName);

        if (player.CurrentBingoGame == null || player.CurrentBingoGame.Id != bingoGameId)
        {
            throw new Exception($"Player {playerName} is not in the current Bingo Game");
        }

        player.CurrentBingoChoices[coordinates.X, coordinates.Y] = !player.CurrentBingoChoices[coordinates.X, coordinates.Y];

        _playerRepository.SaveChanges();
    }

    public bool DoesPlayerExistByName(string name)
    {
        var doesPlayerExist = _playerRepository.DoesPlayerExistByName(name);
        return doesPlayerExist;
    }

    public Player CreatePlayer(string playerName)
    {
        Player player = new()
        {
            Name = playerName
        };

        Player createdPlayer = _playerRepository.AddPlayer(player);

        return createdPlayer;
    }

    public int AddPlayerToCurrentBingoGame(string playerName)
    {
        var player = _playerRepository.GetPlayerByName(playerName);

        var currentBingoGame = _bingoGameService.GetCurrentBingoGame();

        player.CurrentBingoGame = currentBingoGame;

        _playerRepository.SaveChanges();

        return currentBingoGame.Id;
    }
}