using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TeachersBingoApi.Models;
using TeachersBingoApi.Utils.ValueComparers;

namespace TeachersBingoApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Bingo> Bingos { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<BingoGame> BingoGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bingo>().HasData(
            new Bingo { Id = 1, Name = "Bingo 1" }
        );

        modelBuilder.Entity<Phrase>().HasData(
            new Phrase() { Id = 1, Content = "Phrase 1", BingoId = 1 },
            new Phrase() { Id = 2, Content = "Phrase 2", BingoId = 1 },
            new Phrase() { Id = 3, Content = "Phrase 3", BingoId = 1 },
            new Phrase() { Id = 4, Content = "Phrase 4", BingoId = 1 },
            new Phrase() { Id = 5, Content = "Phrase 5", BingoId = 1 },
            new Phrase() { Id = 6, Content = "Phrase 6", BingoId = 1 },
            new Phrase() { Id = 7, Content = "Phrase 7", BingoId = 1 },
            new Phrase() { Id = 8, Content = "Phrase 8", BingoId = 1 },
            new Phrase() { Id = 9, Content = "Phrase 9", BingoId = 1 }
        );

        modelBuilder.Entity<Player>()
            .HasIndex(p => p.Name)
            .IsUnique();


        modelBuilder.Entity<Player>()
            .Property(p => p.CurrentBingoChoices)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<bool[,]>(v) ?? new bool[3, 3],
                new BoolArrayValueComparer());

        modelBuilder.Entity<Player>()
            .Property(p => p.CurrentBingoPhrasesStrings)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<string[,]>(v));

        modelBuilder.Entity<Player>()
            .HasOne(p => p.CurrentBingoGame);

        modelBuilder.Entity<BingoGame>()
            .HasMany(bg => bg.Players)
            .WithMany(p => p.BingoGames);


    }
}