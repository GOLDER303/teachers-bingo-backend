using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Services.Implementations;

public class BingoGameService : IBingoGameService
{
    private readonly IBingoService _bingoService;
    private readonly IBingoGameRepository _bingoGameRepository;

    public BingoGameService(IBingoService bingoService, IBingoGameRepository bingoGameRepository)
    {
        _bingoService = bingoService;
        _bingoGameRepository = bingoGameRepository;
    }

    public BingoGame GetBingoGameWithLeaderboardById(int bingoGameId)
    {
        var bingoGame = _bingoGameRepository.GetBingoGameWithLeaderboardById(bingoGameId);
        return bingoGame;
    }

    public BingoGame GetCurrentBingoGame()
    {
        var currentBingo = _bingoService.GetCurrentBingo();

        if (currentBingo == null)
        {
            // TODO: add custom exception
            throw new Exception("Currently there isn't any bingo games");
        }

        DateTime currentBingoEndDateTime = currentBingo.EndDateTime;

        var latestBingoGame = _bingoGameRepository.GetLatestBingoGameByBingo(currentBingo.Bingo);

        if (latestBingoGame == null || latestBingoGame.EndDateTime < currentBingoEndDateTime)
        {
            latestBingoGame = new() { Bingo = currentBingo.Bingo, EndDateTime = currentBingoEndDateTime, };

            _bingoGameRepository.AddBingoGame(latestBingoGame);
        }

        return latestBingoGame;
    }

    public bool CheckIfPlayerWon(Player player)
    {
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
