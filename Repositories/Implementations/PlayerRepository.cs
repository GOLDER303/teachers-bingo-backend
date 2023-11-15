namespace TeachersBingoApi.Repositories.Implementations;

using TeachersBingoApi.Data;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PlayerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Player GetPlayerByName(string name)
    {
        var player = _dbContext.Players.FirstOrDefault(p => p.Name == name);

        if (player == null)
        {
            throw new KeyNotFoundException($"Player with name: {name} not found");
        }

        return player;
    }

    public bool DoesPlayerExistByName(string name)
    {
        var player = _dbContext.Players.FirstOrDefault(p => p.Name == name);

        if (player == null)
        {
            return false;
        }

        return true;
    }

    public Player AddPlayer(Player player)
    {
        _dbContext.Players.Add(player);
        _dbContext.SaveChanges();

        return player;
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}
