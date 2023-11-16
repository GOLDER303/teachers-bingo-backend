using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBingoApi.Models;

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Name { get; set; }
    public bool[,] CurrentBingoChoices { get; set; } = new bool[3, 3];
    public IEnumerable<BingoGame> BingoGames { get; set; } = new List<BingoGame>();
    private BingoGame? _currentBingoGame;
    public BingoGame? CurrentBingoGame
    {
        get => _currentBingoGame;
        set
        {
            if (_currentBingoGame != value)
            {
                _currentBingoGame = value;
                CurrentBingoChoices = new bool[3, 3];
            }
        }
    }

}