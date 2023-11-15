namespace TeachersBingoApi.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Name { get; set; }
    public bool[,] CurrentBingoChoices { get; set; } = new bool[3, 3];
    public BingoGame? CurrentBingoGame { get; set; }
    public IEnumerable<BingoGame> BingoGames { get; set; } = new List<BingoGame>();
}