using Microsoft.EntityFrameworkCore;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Bingo> Bingos { get; set; }

}