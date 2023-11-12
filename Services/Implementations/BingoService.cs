namespace TeachersBingoApi.Services.Implementations;

using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

public class BingoService : IBingoService
{
    private readonly IBingoRepository _bingoRepository;

    public BingoService(IBingoRepository bingoRepository)
    {
        _bingoRepository = bingoRepository;
    }

    public Bingo GetRandomBingo()
    {
        int bingoCount = _bingoRepository.GetBingoCount();

        Random random = new();

        int randomBingoId = random.Next(1, bingoCount + 1);

        return _bingoRepository.GetBingoById(randomBingoId);
    }
}