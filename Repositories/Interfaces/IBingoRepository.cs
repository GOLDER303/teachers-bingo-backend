namespace TeachersBingoApi.Repositories.Interfaces;

using TeachersBingoApi.Models;

public interface IBingoRepository
{
    Bingo GetBingoById(int id);
    IEnumerable<Bingo> GetAllBingos();
    int GetBingoCount();
    Bingo GetBingoByName(string name);
    Bingo AddBingo(Bingo bingo);
    bool DoesBingoExistByName(string name);
}