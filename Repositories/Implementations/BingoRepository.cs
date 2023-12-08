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
        var bingo = _dbContext.Bingos.Where(b => b.Id == id).Include(b => b.Phrases).FirstOrDefault();

        if (bingo == null)
        {
            throw new KeyNotFoundException($"Bingo with id: {id} not found");
        }

        return bingo;
    }

    public IEnumerable<Bingo> GetAllBingos()
    {
        return _dbContext.Bingos.Include(b => b.Phrases).ToList();
    }

    public int GetBingoCount()
    {
        return _dbContext.Bingos.Count();
    }

    public Bingo GetBingoByName(string name)
    {
        var bingo = _dbContext.Bingos.Where(b => b.Name == name).Include(b => b.Phrases).FirstOrDefault();

        if (bingo == null)
        {
            throw new KeyNotFoundException($"Bingo with name: {name} not found");
        }

        return bingo;
    }

    public Bingo AddBingo(Bingo bingo)
    {
        _dbContext.Bingos.Add(bingo);
        _dbContext.SaveChanges();

        return bingo;
    }

    public bool DoesBingoExistByName(string name)
    {
        var doesBingoExist = _dbContext.Bingos.Any(b => b.Name == name);
        return doesBingoExist;
    }
}
