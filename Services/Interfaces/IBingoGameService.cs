using TeachersBingoApi.Models;

namespace TeachersBingoApi.Services.Interfaces;

public interface IBingoGameService
{
    BingoGame GetCurrentBingoGame();
}
