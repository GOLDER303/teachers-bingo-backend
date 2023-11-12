namespace TeachersBingoApi.Services.Interfaces;

using TeachersBingoApi.Models;

public interface IBingoService
{
    Bingo GetRandomBingo();
}