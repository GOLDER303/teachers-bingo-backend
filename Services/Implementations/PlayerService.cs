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

        if (player.CurrentBingoGame == currentBingoGame)
        {
            return currentBingoGame.Id;
        }

        player.CurrentBingoGame = currentBingoGame;

        _playerRepository.SaveChanges();

        return currentBingoGame.Id;
    }

    public bool CheckIfPlayerWon(string playerName)
    {
        var player = GetPlayerByName(playerName);

        var playerChoices = player.CurrentBingoChoices;

        int bingoSize = 3;

        // Check rows and columns
        for (int i = 0; i < bingoSize; i++)
        {
            bool rowWin = true;
            bool colWin = true;

            for (int j = 0; j < bingoSize; j++)
            {
                // Row
                rowWin = rowWin && playerChoices[i, j];

                // Column
                colWin = colWin && playerChoices[j, i];
            }

            if (rowWin || colWin)
            {
                return true;
            }
        }

        bool firstDiagonalWin = true;
        bool secondDiagonalWin = true;

        // Check diagonals
        for (int i = 0; i < bingoSize; i++)
        {
            firstDiagonalWin = firstDiagonalWin && playerChoices[i, i];
            secondDiagonalWin = secondDiagonalWin && playerChoices[i, bingoSize - 1 - i];
        }

        if (firstDiagonalWin || secondDiagonalWin)
        {
            return true;
        }

        return false;
    }
}