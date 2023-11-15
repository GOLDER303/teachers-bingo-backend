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
            latestBingoGame = new()
            {
                Bingo = currentBingo.Bingo,
                EndDateTime = currentBingoEndDateTime,
            };

            _bingoGameRepository.AddBingoGame(latestBingoGame);
        }

        return latestBingoGame;
    }

}
