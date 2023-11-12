namespace TeachersBingoApi.Services;

using TeachersBingoApi.Models;

public interface IBingoService
{
    Bingo GetRandomBingo();
}