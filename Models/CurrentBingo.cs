namespace TeachersBingoApi.Models;

public class CurrentBingo
{
    public required Bingo Bingo { get; set; }
    public required DateTime EndDateTime { get; set; }
}
