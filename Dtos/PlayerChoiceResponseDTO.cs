namespace TeachersBingoApi.Dtos;

public record PlayerChoiceResponseDTO
{
    public required bool[,] SerializedPlayerChoices { get; init; }
    public required bool HasPlayerWon { get; init; }
}
