namespace TeachersBingoApi.Services.Interfaces;

using TeachersBingoApi.Models;

public interface IBingoService
{
    CurrentBingo? GetCurrentBingo();
}