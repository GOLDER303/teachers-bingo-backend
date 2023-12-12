using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBingoApi.Models;

public class BingoGame
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required DateTime EndDateTime { get; set; }

    public IEnumerable<Player> Players { get; set; } = new List<Player>();

    public int BingoId { get; set; }
    public required Bingo Bingo { get; set; }

    public int LeaderboardId { set; get; }
    public Leaderboard Leaderboard { get; set; } = new Leaderboard();
}
