namespace TeachersBingoApi.Repositories.Implementations;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeachersBingoApi.Data;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;

public class BingoRepository : IBingoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BingoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Bingo GetBingoById(int id)
    {
        var bingo = _dbContext.Bingos.FirstOrDefault(category => category.Id == id);

        if (bingo == null)
        {
            throw new KeyNotFoundException($"Bingo with id: {id} not found");
        }

        return bingo;
    }

    public IEnumerable<Bingo> GetAllBingos()
    {
        return _dbContext.Bingos.ToList();
    }
}