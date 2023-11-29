namespace TeachersBingoApi.Dtos;

public record PlayerChoiceResponseDTO
{
    public required bool[,] CurrentChoices { get; init; }
    public required bool PlayerHasWon { get; init; }
}
