using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBingoApi.Models;

public class LeaderboardPosition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required int Position { get; set; }

    public int PlayerId { get; set; }
    public required Player Player { get; set; }

    public int LeaderboardId { get; set; }
    public required Leaderboard Leaderboard { get; set; }
}
