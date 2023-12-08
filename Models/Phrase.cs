using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBingoApi.Models;

public class Phrase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public required string Content { get; set; }

    public int BingoId { get; set; }
    public Bingo Bingo { get; set; } = null!;
}
